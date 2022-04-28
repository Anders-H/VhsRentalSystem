using VhsRental.Screens;

namespace VhsRental;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_Shown(object sender, EventArgs e)
    {
        Refresh();
        GetScreen<MainMenuScreen>();
    }

    public T GetScreen<T>() where T : UserControl, IScreen, new()
    {
        T? ret = default;

        foreach (UserControl c in Controls)
        {
            if (c is T control)
            {
                control.Enabled = true;
                control.BringToFront();
                control.Focus();
                ret = control;
                continue;
            }

            c.Enabled = false;
        }

        if (ret != null)
        {
            ret.Initialize();
            return ret;
        }

        ret = new T();
        ret.Dock = DockStyle.Fill;
        Controls.Add(ret);
        ret.BringToFront();
        ret.Initialize();
        ret.Focus();
        return ret;
    }
}