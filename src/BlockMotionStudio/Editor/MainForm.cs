using System.Drawing;
using System.Windows.Forms;

namespace BlockMotionStudio.Editor;

public sealed class MainForm : Form
{
    private readonly StatusStrip _statusStrip = new();
    private readonly ToolStripStatusLabel _statusLabel = new("Ready");

    public MainForm()
    {
        Text = "BlockMotion Studio";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1100, 700);
        Size = new Size(1440, 900);
        BackColor = Color.FromArgb(30, 32, 38);
        ForeColor = Color.Gainsboro;
        Font = new Font("Segoe UI", 9F);

        BuildMenu();
        BuildWorkspace();

        _statusStrip.Items.Add(_statusLabel);
        _statusStrip.BackColor = Color.FromArgb(37, 40, 47);
        _statusStrip.ForeColor = Color.Gainsboro;
        Controls.Add(_statusStrip);
    }

    private void BuildMenu()
    {
        var menu = new MenuStrip
        {
            BackColor = Color.FromArgb(37, 40, 47),
            ForeColor = Color.Gainsboro,
            Renderer = new ToolStripProfessionalRenderer(new DarkColorTable())
        };

        menu.Items.Add("File");
        menu.Items.Add("Edit");
        menu.Items.Add("Object");
        menu.Items.Add("Animation");
        menu.Items.Add("Render");
        menu.Items.Add("Window");
        menu.Items.Add("Help");
        MainMenuStrip = menu;
        Controls.Add(menu);
    }

    private void BuildWorkspace()
    {
        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 2,
            BackColor = Color.FromArgb(30, 32, 38),
            Padding = new Padding(6)
        };
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 72));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 28));

        root.Controls.Add(CreatePanel("Scene"), 0, 0);
        root.Controls.Add(CreatePanel("3D Viewport — renderer initialization pending"), 1, 0);
        root.Controls.Add(CreatePanel("Inspector"), 2, 0);
        root.Controls.Add(CreatePanel("Timeline"), 0, 1);
        root.SetColumnSpan(root.GetControlFromPosition(0, 1)!, 3);

        Controls.Add(root);
        root.BringToFront();
        MainMenuStrip?.BringToFront();
    }

    private static Control CreatePanel(string title)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(40, 43, 51),
            Margin = new Padding(4)
        };
        var header = new Label
        {
            Text = title,
            Dock = DockStyle.Top,
            Height = 32,
            Padding = new Padding(10, 8, 0, 0),
            ForeColor = Color.FromArgb(225, 228, 235),
            BackColor = Color.FromArgb(49, 53, 63),
            Font = new Font("Segoe UI Semibold", 9F)
        };
        panel.Controls.Add(header);
        return panel;
    }

    private sealed class DarkColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder => Color.FromArgb(55, 59, 69);
        public override Color MenuItemSelected => Color.FromArgb(63, 70, 84);
        public override Color MenuItemBorder => Color.FromArgb(75, 84, 102);
        public override Color ToolStripDropDownBackground => Color.FromArgb(37, 40, 47);
        public override Color ImageMarginGradientBegin => Color.FromArgb(37, 40, 47);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(37, 40, 47);
        public override Color ImageMarginGradientEnd => Color.FromArgb(37, 40, 47);
    }
}
