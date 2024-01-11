using System.Runtime.InteropServices;

namespace MyWinFormsApp
{
    public class MyHookClass : NativeWindow
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);
        
        uint simpr1, simpr2;
        private Form1 form1;

        public MyHookClass(Form1 hWnd)
        {
            simpr1 = RegisterWindowMessage("MyMessage1");
            simpr2 = RegisterWindowMessage("MyMessage2");
            this.AssignHandle(hWnd.Handle);
            this.form1 = hWnd;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            int wparamhi,wparamlo,wparam;
            int lParam = Convert.ToInt32("" + m.LParam);
            
            if (m.Msg == simpr1){                                                        //условия
                wparam = Convert.ToInt32("" + m.WParam);
                wparamhi = wparam / 65536;
                wparamlo = wparam - wparamhi * 65536;                        
                if (wparamlo == 1){                                                      // таблица 1 
                    switch (lParam)
                    {
                        case 1: m.Result = new IntPtr(form1.stop); break;                // таблица 2 условие 1
                    }
                    form1.listBox1.Items.Add("Таблица 1 Условие " + lParam.ToString() + ". Результат: " + m.Result.ToString());
                }
                else if (wparamlo == 2){                                                 // таблица 2 
                    switch (lParam)                
                    {
                        case 1: m.Result = new IntPtr(form1.condition_1_table2()); break;// таблица 2 условие 1
                        case 2: m.Result = new IntPtr(form1.condition_2_table2()); break;// таблица 2 условие 2
                        case 3: m.Result = new IntPtr(form1.condition_3_table2()); break;// таблица 2 условие 3
                        case 4: m.Result = new IntPtr(form1.condition_4_table2()); break;// таблица 2 условие 4
                    }
                    if (lParam == 2)
                        form1.listBox1.Items.Add("Таблица 2 Условие " + lParam.ToString() + ". Результат: " + m.Result.ToString());
                    form1.listBox1.SelectedIndex = form1.listBox1.Items.Count - 1;
                }
                else if (wparamlo == 3){                                                 // таблица 3 
                    switch (lParam)
                    {
                        case 1: m.Result = new IntPtr(form1.condition_1_table3()); break;// таблица 3 условие 1
                        case 2: m.Result = new IntPtr(form1.condition_2_table3()); break;// таблица 3 условие 2
                        case 3: m.Result = new IntPtr(form1.condition_3_table3()); break;// таблица 3 условие 3
                        case 4: m.Result = new IntPtr(form1.condition_4_table3()); break;// таблица 3 условие 4
                        case 5: m.Result = new IntPtr(form1.condition_5_table3()); break;// таблица 3 условие 5
                    }
                    form1.listBox1.Items.Add("Таблица 3 Условие " + lParam.ToString() + ". Результат: " + m.Result.ToString());
                    form1.listBox1.SelectedIndex = form1.listBox1.Items.Count - 1;
                }
                else if (wparamlo == 4){                                                 // таблица 4
                    switch (lParam)
                    {
                        case 1: m.Result = new IntPtr(form1.condition_1_table4()); break;// таблица 4 условие 1
                        case 2: m.Result = new IntPtr(form1.condition_2_table4()); break;// таблица 4 условие 2
                    }
                    form1.listBox1.Items.Add("Таблица 4 Условие " + lParam.ToString() + ". Результат: " + m.Result.ToString());
                    form1.listBox1.SelectedIndex = form1.listBox1.Items.Count - 1;
                }
                else if (wparamlo == 5){                                                 // таблица 5 
                    switch (lParam)
                    {
                        case 1: m.Result = new IntPtr(form1.condition_1_table5()); break;// таблица 5 условие 1
                        case 2: m.Result = new IntPtr(form1.condition_2_table5()); break;// таблица 5 условие 2
                        case 3: m.Result = new IntPtr(form1.condition_3_table5()); break;// таблица 5 условие 3
                        case 4: m.Result = new IntPtr(form1.condition_4_table5()); break;// таблица 5 условие 4
                    }
                    form1.listBox1.Items.Add("Таблица 5 Условие " + lParam.ToString() + ". Результат: " + m.Result.ToString());
                    form1.listBox1.SelectedIndex = form1.listBox1.Items.Count - 1;
                }
            }
            else if (m.Msg == simpr2){                              //действия
                wparam = Convert.ToInt32("" + m.WParam);
                wparamhi = wparam / 65536;
                wparamlo = wparam - wparamhi * 65536;
                if (0 == 0){
                    if (wparamlo == 1)                              // таблица 1 
                    {
                    }
                    else if (wparamlo == 2)                         // таблица 2 
                    {
                        switch (lParam)
                        {
                            case 1: break;                          // таблица 2 Действие 1
                        }
                        form1.listBox1.Items.Add("Таблица 2 Действие " + lParam.ToString());
                        form1.listBox1.SelectedIndex = form1.listBox1.Items.Count - 1;
                    }
                    else if (wparamlo == 3)                         // таблица 3 
                    {
                        switch (lParam)
                        {
                            case 1: form1.Move_up(); break;         // таблица 3 Действие 1
                            case 2: form1.Move_down(); break;       // таблица 3 Действие 2
                            case 3: break;                          // таблица 3 Действие 3
                        }
                        form1.listBox1.Items.Add("Таблица 3 Действие " + lParam.ToString());
                        form1.listBox1.SelectedIndex = form1.listBox1.Items.Count - 1;
                    }
                    else if (wparamlo == 4)                         // таблица 4 
                    {
                        switch (lParam)
                        {
                            case 1: form1.Rem_People(); break;      // таблица 4 Действие 1
                            case 2: break;                          // таблица 4 Действие 2
                        }
                        form1.listBox1.Items.Add("Таблица 4 Действие " + lParam.ToString());
                        form1.listBox1.SelectedIndex = form1.listBox1.Items.Count - 1;
                    }
                    else if (wparamlo == 5)                         // таблица 5 
                    {
                        switch (lParam)
                        {
                            case 1: form1.Add_People(); break;      // таблица 5 Действие 1
                            case 2: break;                          // таблица 5 Действие 2
                        }
                        form1.listBox1.Items.Add("Таблица 5 Действие " + lParam.ToString());
                        form1.listBox1.SelectedIndex = form1.listBox1.Items.Count - 1;
                    }
                    Task.Delay(300).Wait();
                    Application.DoEvents();
                }
                m.Result = new IntPtr(1);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

    }
}
