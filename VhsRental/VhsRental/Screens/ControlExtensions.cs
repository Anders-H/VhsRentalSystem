namespace VhsRental.Screens;

public static class ControlExtensions
{
    public static void SetToWaitMode(this Control me, bool waitMode)
    {
        if (waitMode)
        {
            me.Cursor = Cursors.WaitCursor;

            foreach (Control control in me.Controls)
            {
                var tag = GetTag(me);

                tag.Enabled = control.Enabled;
            }

            me.Refresh();
            return;
        }

        foreach (Control control in me.Controls)
        {
            if (me.Tag is not ControlTagData tag)
                continue;

            control.Enabled = tag.Enabled;
        }

        me.Cursor = Cursors.Default;
        me.Refresh();
    }

    public static ControlTagData GetTag(this Control me)
    {
        var tag = me.Tag as ControlTagData;

        if (tag == null)
        {
            tag = new ControlTagData();
            me.Tag = tag;
        }

        return tag;
    }
}