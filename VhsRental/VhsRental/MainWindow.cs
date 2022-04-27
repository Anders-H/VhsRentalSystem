using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        var m = GetScreen<MainMenuScreen>();
    }

    private T GetScreen<T>() where T : UserControl, IScreen, new()
    {
        T? ret = default;

        foreach (UserControl c in Controls)
        {
            if (c is T control)
            {
                control.Enabled = true;
                control.BringToFront();
                ret = control;
                continue;
            }

            c.Enabled = false;
        }

        if (ret != null)
        {
            ((IScreen)ret).Initialize();
            return ret;
        }

        ret = new T();
        ret.Dock = DockStyle.Fill;
        Controls.Add(ret);
        ret.BringToFront();
        ((IScreen)ret).Initialize();
        return ret;
    }
}