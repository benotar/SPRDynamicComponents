namespace ClassWork_24_02_2024_Dynamic.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        clickMeButton = new Button();
        SuspendLayout();
        // 
        // clickMeButton
        // 
        clickMeButton.Location = new Point(12, 12);
        clickMeButton.Name = "clickMeButton";
        clickMeButton.Size = new Size(213, 56);
        clickMeButton.TabIndex = 0;
        clickMeButton.Text = "Click me";
        clickMeButton.UseVisualStyleBackColor = true;
        clickMeButton.Click += ClickMeClick;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(237, 342);
        Controls.Add(clickMeButton);
        Name = "MainForm";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button clickMeButton;
}
