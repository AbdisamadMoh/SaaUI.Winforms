using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// A panel that Organizes SaaChatBubbles.
    /// </summary>
    [Description("A panel that Organizes SaaChatBubbles.")]
    [ToolboxBitmap(typeof(SaaChatPanel), "icons.SaaChatPanel.bmp")]
    public partial class SaaChatPanel : UserControl
    {
        public SaaChatPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
            // tableLayoutPanel1.CellPaint += TableLayoutPanel1_CellPaint;
            // tableLayoutPanel1.Scroll += TableLayoutPanel1_Scroll;
            //tableLayoutPanel1.Controls.Clear();
            //for (int i = 0; i < 20; i++)
            //{
            //    var c = new SaaChatBubble();
            //    this.tableLayoutPanel1.Controls.Add(c);
            //    InvalidateBubbles();
            //}
            BackColor = Color.White;
        }



        Dictionary<string, SaaChatBubble> ChatBubbleIDList = new Dictionary<string, SaaChatBubble>();
        List<SaaChatBubble> ChatBubbleNOIDList = new List<SaaChatBubble>();

        /// <summary>
        /// Add message to the chat panel.
        /// </summary>
        /// <param name="message">Message to add</param>
        public void AddMessage(SaaChatBubble message)
        {
            if (message != null)
            {

                AddMessage(message, message.Id);
                InvalidateBubbles();
            }
            else
            {
                throw new Exception("Make sure the 'SaaChatBubble' is not null");
            }
        }

        /// <summary>
        /// Add message to the chat panel with an id.
        /// </summary>
        /// <param name="message">Message to add</param>
        /// <param name="messageID">Id of the message</param>
        public void AddMessage(SaaChatBubble message, string messageID)
        {
            if (message != null)
            {
                this.tableLayoutPanel1.Controls.Add(message);
                ChatBubbleIDList.Add(messageID, message);
                InvalidateBubbles();
            }
            else
            {
                throw new Exception("Make sure the 'SaaChatBubble' is not null");
            }
        }

        /// <summary>
        /// Remove a message from the chat panel with its messageId.
        /// </summary>
        /// <param name="messageID"></param>
        public void Remove(string messageID)
        {
            if (!string.IsNullOrEmpty(messageID) && ChatBubbleIDList.ContainsKey(messageID))
            {
                var c = ChatBubbleIDList[messageID];
                ChatBubbleIDList.Remove(messageID);
                if (tableLayoutPanel1.Controls.Contains(c))
                {
                    tableLayoutPanel1.Controls.Remove(c);
                }
            }

        }

        /// <summary>
        /// Remove a message from the chat panel.
        /// </summary>
        /// <param name="message"></param>
        public void Remove(SaaChatBubble message)
        {
            var k = this.GetMessageId(message);
            if (!string.IsNullOrEmpty(k) && ChatBubbleIDList.ContainsKey(k))
            {
                ChatBubbleIDList.Remove(k);
                if (tableLayoutPanel1.Controls.Contains(message))
                {
                    tableLayoutPanel1.Controls.Remove(message);
                }
            }

        }

        private void Remove(int index)//bug where index deleted is out of bound.
        {
            var message = this[index];
            if (message != null)
            {
                var k = this.GetMessageId(message);
                if (!string.IsNullOrEmpty(k) && ChatBubbleIDList.ContainsKey(k))
                {
                    ChatBubbleIDList.Remove(k);
                    tableLayoutPanel1.Controls.Clear();
                    foreach (var sc in ChatBubbleIDList.Values)
                    {
                        tableLayoutPanel1.Controls.Add(sc);
                        this.InvalidateBubbles();
                    }
                }

            }
        }

        /// <summary>
        /// Remove all messages in the chat panel.
        /// </summary>
        public void RemoveAll()
        {
            tableLayoutPanel1.Controls.Clear();
            ChatBubbleIDList.Clear();
        }

        /// <summary>
        /// Gets all messages in the chat panel.
        /// </summary>
        [Browsable(false)]
        public SaaChatBubble[] Messages
        {
            get
            {
                List<SaaChatBubble> ls = new List<SaaChatBubble>();
                foreach (SaaChatBubble b in ChatBubbleIDList.Values)
                {
                    ls.Add(b);
                }
                return ls.ToArray();
            }
        }

        /// <summary>
        /// Get a message by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public SaaChatBubble GetMessage(int index)
        {
            return this[index];
        }

        /// <summary>
        /// Get a message by messageId
        /// </summary>
        /// <param name="MessageId"></param>
        /// <returns></returns>
        public SaaChatBubble GetMessage(string MessageId)
        {
            return this[MessageId];
        }

        /// <summary>
        /// Gets the index of the specified message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int GetMessageIndex(SaaChatBubble message)
        {
            return this[message];
        }

        /// <summary>
        /// Gets the messageId of the specified message. 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string GetMessageId(SaaChatBubble message)
        {
            if (message == null) return "";
            string msg = "";
            foreach (var m in ChatBubbleIDList.Keys)
            {
                if (ChatBubbleIDList[m] != null && ChatBubbleIDList[m].Id == message.Id) msg = m;
                break;
            }
            return msg;
        }

        /// <summary>
        /// Get a message by Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public SaaChatBubble this[int index]
        {
            get
            {
                return (SaaChatBubble)this.tableLayoutPanel1.GetControlFromPosition(0, index);
            }
        }

        /// <summary>
        /// Gets the index of the specified message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int this[SaaChatBubble message]
        {
            get
            {
                return tableLayoutPanel1.GetPositionFromControl(message).Row;
            }
        }

        /// <summary>
        /// Gets a message by messageId
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns></returns>
        public SaaChatBubble this[string messageID]
        {
            get
            {
                return ChatBubbleIDList[messageID];
            }
        }

        /// <summary>
        /// Invalidates and redraws messages in the chat panel.
        /// </summary>
        public void InvalidateBubbles()
        {
            TableLayoutRowStyleCollection styles = tableLayoutPanel1.RowStyles;
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.AutoSize;
            }
        }

        private void TableLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            // tableLayoutPanel1.Invalidate();
        }

        private void TableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            // var g = e.Graphics;
            //g.DrawString(e.Row.ToString(), this.Font, Brushes.Red, 0, 0);
            return;
            Control c = this.tableLayoutPanel1.GetControlFromPosition(e.Column, e.Row);

            if (c != null)
            {
                Graphics g = e.Graphics;
                g.DrawString(e.Row.ToString(), this.Font, Brushes.Red, 0, 0);

                g.DrawRectangle(
                    Pens.Red,
                    e.CellBounds.Location.X + 1,
                    e.CellBounds.Location.Y + 1,
                    e.CellBounds.Width - 2, e.CellBounds.Height - 2);

                g.FillRectangle(
                    Brushes.Blue,
                    e.CellBounds.Location.X + 1,
                    e.CellBounds.Location.Y + 1,
                    e.CellBounds.Width - 2,
                    e.CellBounds.Height - 2);
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        private void Draw()
        {
        }
    }
    internal class chatB : Control //im not sure the use of this.
    {
        Font f;
        string s;
        public chatB(string text, Font font)
        {
            s = text;
            f = font;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var h = this.Height = s.GetSize(f).Height;
            var w = this.Width = s.GetSize(f).Width;
            g.DrawString(s, f, Brushes.Red, 0, 0);
            base.OnPaint(e);
        }
    }
}
