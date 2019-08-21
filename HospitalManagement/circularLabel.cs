using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement
{
    class circularLabel : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grapphic = new GraphicsPath();
            grapphic.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grapphic);
            base.OnPaint(e);
        }
    }
}
