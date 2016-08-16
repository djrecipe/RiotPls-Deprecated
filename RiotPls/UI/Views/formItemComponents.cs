using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API.Serialization.Items;
using RiotPls.UI.Controls;
using RiotPls.UI.Models;

namespace RiotPls.UI.Views
{
    public class formItemComponents : Form
    {
        #region Instance Members
        private System.ComponentModel.IContainer components = null;
        private Timer timerFocus;
        private formItemComponentsModel model = null;
        private ItemInfo item = null;
        #endregion
        #region Instance Methods
        public formItemComponents(ItemInfo item_in)
        {
            if(item_in == null)
                throw new ArgumentNullException("item_in", "Invalid item");
            this.item = item_in;
            this.InitializeComponent();
            return;
        }

        private Size AddSlots(List<DropSlot> slots)
        {
            if(slots.Count < 1)
                return new Size(10, 10);
            int current_row_width = 0;
            foreach (DropSlot slot in slots)
            {
                slot.Location = new Point(10 + current_row_width, 10);
                current_row_width += slot.Width;
                this.Controls.Add(slot);
            }
            return new Size(current_row_width, 10 + slots[0].Height + 10);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerFocus = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerFocus
            // 
            this.timerFocus.Interval = 300;
            this.timerFocus.Tick += new System.EventHandler(this.timerFocus_Tick);
            // 
            // formItemComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(120, 150);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formItemComponents";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formItemComponents";
            this.Load += new System.EventHandler(this.formItemComponents_Load);
            this.MouseLeave += new System.EventHandler(this.formItemComponents_MouseLeave);
            this.ResumeLayout(false);

        }
        #endregion
        #region Event Methods
        private void formItemComponents_Load(object sender, System.EventArgs e)
        {
            this.model = new formItemComponentsModel(this.item);
            List<DropSlot> slots = this.model.GenerateDropSlots();
            this.Size = this.AddSlots(slots);
            Console.WriteLine("Width: {0}", this.DisplayRectangle.Width);
            this.Width += 20;
            if (this.Owner is formItemComponents)
                this.timerFocus.Start();
            return;
        }
        private void formItemComponents_MouseLeave(object sender, EventArgs e)
        {
            this.timerFocus.Start();
            return;
        }
        private void timerFocus_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed)
                return;
            // this rect
            Rectangle rect = this.ClientRectangle;
            rect.Location = this.PointToScreen(rect.Location);
            // parent rect
            Rectangle parent_rect = Rectangle.Empty;
            if (this.Owner is formItemComponents)
            {
                parent_rect = this.Owner.ClientRectangle;
                parent_rect.Location = this.Owner.PointToScreen(parent_rect.Location);
            }
            if (!rect.Contains(Control.MousePosition) && !parent_rect.Contains(Control.MousePosition))
                this.Close();
            return;
        }
        #endregion
        #region Override Methods
        /// <summary>
        /// Clean up any resources being used.
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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Rectangle rect = new Rectangle(this.ClientRectangle.Left+1, this.ClientRectangle.Top + 1, this.ClientRectangle.Width - 2, this.ClientRectangle.Height -2 );
            e.Graphics.DrawRectangle(new Pen(Color.Blue), rect);
            return;
        }
        #endregion

    }
}
