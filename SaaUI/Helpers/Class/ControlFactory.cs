using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace SaaUI
{
    #region ControlFactory
    /// <summary>
    /// Use this helper class to clone, copy and paste controls and also copy/paste properties between controls.
    /// </summary>
    internal static class ControlFactory
    {
        /// <summary>
        /// Create a control
        /// </summary>
        /// <param name="ControlName"></param>
        /// <param name="partialName"></param>
        /// <returns></returns>
        public static Control CreateControl(string ControlName, string partialName)
        {
            try
            {
                Control ctrl;
                switch (ControlName)
                {
                    case "Label":
                        ctrl = new Label();
                        break;
                    case "TextBox":
                        ctrl = new TextBox();
                        break;
                    case "PictureBox":
                        ctrl = new PictureBox();
                        break;
                    case "ListView":
                        ctrl = new ListView();
                        break;
                    case "ComboBox":
                        ctrl = new ComboBox();
                        break;
                    case "Button":
                        ctrl = new Button();
                        break;
                    case "CheckBox":
                        ctrl = new CheckBox();
                        break;
                    case "MonthCalender":
                        ctrl = new MonthCalendar();
                        break;
                    case "DateTimePicker":
                        ctrl = new DateTimePicker();
                        break;
                    default:
                        Assembly controlAsm = Assembly.LoadWithPartialName(partialName);
                        Type controlType = controlAsm.GetType(partialName + "." + ControlName);
                        ctrl = (Control)Activator.CreateInstance(controlType);
                        break;

                }
                return ctrl;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("create control failed:" + ex.Message);
                return new Control();
            }
        }

        public static void SetControlProperties(Control control, Hashtable propertyList)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(control);

            foreach (PropertyDescriptor myProperty in properties)
            {
                if (propertyList.Contains(myProperty.Name))
                {
                    Object obj = propertyList[myProperty.Name];
                    try
                    {
                        myProperty.SetValue(control, obj);
                    }
                    catch (Exception ex)
                    {
                        //do nothing, just continue
                        System.Diagnostics.Trace.WriteLine(ex.Message);
                    }

                }

            }

        }

        /// <summary>
        /// Create a copy of a control
        /// </summary>
        /// <param name="control">Control to be cloned</param>
        /// <returns> returns new very same control</returns>
        public static Control CloneControl(Control control)
        {

            CBFormCtrl cbCtrl = new CBFormCtrl(control);
            Control newCtrl = ControlFactory.CreateControl(cbCtrl.CtrlName, cbCtrl.PartialName);

            ControlFactory.SetControlProperties(newCtrl, cbCtrl.PropertyList);

            return newCtrl;
        }

        /// <summary>
        /// Copy a control to the clipboard
        /// </summary>
        /// <param name="control">Control to be copied</param>
        public static void CopyControlToClipBoard(Control control)
        {
            CBFormCtrl cbCtrl = new CBFormCtrl(control);
            IDataObject ido = new DataObject();

            ido.SetData(CBFormCtrl.Format.Name, true, cbCtrl);
            Clipboard.SetDataObject(ido, false);

        }

        /// <summary>
        /// Get control that you have copied to the clipboard with <see cref="CopyControlToClipBoard(Control)"/>
        /// </summary>
        /// <returns>Returns copied control</returns>
        public static Control GetControlFromClipBoard()
        {
            Control ctrl = new Control();

            IDataObject ido = Clipboard.GetDataObject();
            if (ido.GetDataPresent(CBFormCtrl.Format.Name))
            {
                CBFormCtrl cbCtrl = ido.GetData(CBFormCtrl.Format.Name) as CBFormCtrl;

                ctrl = ControlFactory.CreateControl(cbCtrl.CtrlName, cbCtrl.PartialName);
                ControlFactory.SetControlProperties(ctrl, cbCtrl.PropertyList);

            }
            return ctrl;
        }


    }

    #endregion

    #region Clipboard Support

    [Serializable()]
    internal class CBFormCtrl//clipboard form control
    {
        private static DataFormats.Format format;
        private string ctrlName;
        private string partialName;
        private Hashtable propertyList = new Hashtable();

        static CBFormCtrl()
        {
            // Registers a new data format with the windows Clipboard
            format = DataFormats.GetFormat(typeof(CBFormCtrl).FullName);
        }

        public static DataFormats.Format Format
        {
            get
            {
                return format;
            }
        }
        public string CtrlName
        {
            get
            {
                return ctrlName;
            }
            set
            {
                ctrlName = value;
            }
        }

        public string PartialName
        {
            get
            {
                return partialName;
            }
            set
            {
                partialName = value;
            }
        }

        public Hashtable PropertyList
        {
            get
            {
                return propertyList;
            }

        }


        public CBFormCtrl()
        {

        }

        public CBFormCtrl(Control ctrl)
        {
            CtrlName = ctrl.GetType().Name;
            PartialName = ctrl.GetType().Namespace;

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(ctrl);

            foreach (PropertyDescriptor myProperty in properties)
            {
                try
                {
                    if (myProperty.PropertyType.IsSerializable)
                        propertyList.Add(myProperty.Name, myProperty.GetValue(ctrl));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                    //do nothing, just continue
                }

            }

        }


    }
    #endregion
}
