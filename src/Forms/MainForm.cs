namespace ClassWork_24_02_2024_Dynamic.Forms;

public partial class MainForm : Form
{
    private int _nextY = 30;

    private FileInfo[]? _files;

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainFormLoad(object sender, EventArgs e)
    {
        var directory = new DirectoryInfo(".");

        _files = directory.GetFiles();

        RenderFiles();
    }


    private void RenderFiles()
    {
        for (int i = 0; i < _files.Length; i++)
        {
            RenderFile(i);
        }
    }

    private void RenderFile(int fileIndex)
    {
        var file = _files[fileIndex];

        var textBox = new TextBox();
        textBox.Width = 230;
        textBox.Text = file.Name;
        textBox.Tag = fileIndex;
        textBox.Location = new Point(12, _nextY);
        Controls.Add(textBox);

        var button = new Button();
        button.Click += UpdateButtonClick;
        button.Location = new Point(260, _nextY);
        button.Text = "Update";
        button.Tag = fileIndex;
        Controls.Add(button);

        _nextY += 25;
    }

    private void UpdateButtonClick(object? sender, EventArgs e)
    {
        var button = sender as Button;

        var fileIndex = (int)button.Tag;

        foreach (var control in Controls)
        {
            if (control is TextBox textBox)
            {
                if ((int)textBox.Tag == fileIndex)
                {
                    var text = textBox.Text;

                    File.Move(_files[fileIndex].FullName, textBox.Text);

                    MessageBox.Show("Renamed!");


                }
            }
        }
    }
}