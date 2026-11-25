namespace ZooDirector;

public class ГлавнаяФорма : Form
{
    private Зоопарк zoo = new();
    private Директор director;
    private readonly TextBox name = new() { Text = "Директор", Width = 160 };
    private readonly FlowLayoutPanel residents = new() { Width = 590, Height = 112 };
    private readonly ComboBox foods = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 235 };
    private readonly NumericUpDown amount = new() { Minimum = 1, Maximum = 1000, Width = 70 };
    private readonly Label status = new() { AutoSize = true };
    private readonly Label message = new() { AutoSize = true };
    private readonly Button buy = new() { Text = "Купить", AutoSize = true };
    private readonly Button next = new() { Text = "Следующий день", AutoSize = true };

    public ГлавнаяФорма()
    {
        Text = "Директор зоопарка";
        ClientSize = new Size(650, 410);
        AutoScroll = true;
        director = new Директор(name.Text, 1000, zoo);
        var panel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
            WrapContents = false, AutoScroll = true, Padding = new Padding(12) };
        Controls.Add(panel);
        var restart = new Button { Text = "Начать заново", AutoSize = true };
        restart.Click += (_, _) => {
            zoo = new Зоопарк();
            director = new Директор(name.Text, 1000, zoo);
            RefreshState("Купите корм и нажмите на животное.");
        };
        panel.Controls.Add(Row(new Label { Text = "Имя директора", AutoSize = true }, name, restart));
        panel.Controls.Add(status);
        panel.Controls.Add(new Label { Text = "Нажмите на животное, чтобы покормить", AutoSize = true });
        panel.Controls.Add(residents);
        panel.Controls.Add(new Label { Text = "Запас корма и цена одной порции", AutoSize = true });
        panel.Controls.Add(Row(foods, amount, buy));
        panel.Controls.Add(next);
        panel.Controls.Add(message);
        buy.Click += (_, _) => RefreshState(foods.SelectedItem is Корм food && director.BuyFood(food, (int)amount.Value)
            ? "Запас пополнен." : "Не хватает денег.");
        next.Click += (_, _) => { zoo.NextDay(); RefreshState("Прошёл день."); };
        RefreshState("Купите корм и нажмите на животное.");
    }
    private static FlowLayoutPanel Row(params Control[] controls)
    {
        var row = new FlowLayoutPanel { AutoSize = true, WrapContents = false };
        row.Controls.AddRange(controls);
        return row;
    }
    private void RefreshState(string text)
    {
        status.Text = $"День {Math.Min(zoo.Day, Зоопарк.LastDay)}/10. {director.GetName()}: {director.Money} монет. Средняя сытость: {zoo.GetAverageSatiety():F1}";
        int selected = Math.Max(0, foods.SelectedIndex);
        foods.Items.Clear();
        foods.Items.AddRange(zoo.FoodStock.Cast<object>().ToArray());
        foods.SelectedIndex = selected;
        while (residents.Controls.Count > 0) residents.Controls[0].Dispose();
        foreach (var animal in zoo.Animals)
        {
            var button = new Button { Text = animal.ToString(), AutoSize = true, Enabled = !zoo.Finished };
            button.Click += (_, _) => RefreshState(zoo.FeedAnimal(animal)
                ? "Животное поело." : "Животное сыто или подходящий корм закончился.");
            residents.Controls.Add(button);
        }
        buy.Enabled = next.Enabled = !zoo.Finished;
        message.Text = zoo.Finished ? (zoo.Animals.Count == 0 ? "Все животные погибли." : "Победа! Прошло 10 дней.") : text;
    }
}
