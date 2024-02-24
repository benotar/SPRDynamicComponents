namespace ClassWork_24_02_2024_Dynamic.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void ClickMeClick(object sender, EventArgs e)
    {
        var newLabel = new Label();
        newLabel.Text = DateTime.Now.Millisecond.ToString();
        newLabel.Location = new Point(10, 100);


        // Добавити компонент в список і відобразити на екрані
        Controls.Add(newLabel);
    }
}
