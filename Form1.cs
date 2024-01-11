namespace MyWinFormsApp;
public partial class Form1 : Form
{
    public int stop = 0;
    List<People> peoples;
    public Elevator elevator;
    public Image imgElevator, man, badman, up, down, updown, buttons;
    public struct People
    {
        public int start_floor, end_floor, bad;
        public People(int s, int e, int b){ start_floor = s; end_floor = e; bad = b; }
    }
    public struct Elevator
    {
        public int current_floor, max_pas, direction_up;
        public List<People> peoples = new List<People>();
        public Elevator(int c = 0, int m = 3, int d = 1){ current_floor = c; max_pas = m; direction_up = d; }

        public void Add_People(People p){ peoples.Add(p); }
        public void Rem_People(People p){ peoples.Remove(p); }
        public void Move_up(){ current_floor += 1; direction_up = 1; }
        public void Move_down(){ current_floor -= 1; direction_up = 0; }
    }
    public void Rem_People(){
        for (int i = elevator.peoples.Count - 1; i >= 0; i--){
            var people = elevator.peoples[i];
            if (elevator.current_floor == people.end_floor)
                elevator.Rem_People(people);
        }
        Draw();
    }
    public void Add_People(){
        for (int i = peoples.Count - 1; i >= 0; i--){
            var people = peoples[i];
            if (elevator.current_floor == people.start_floor){
                int dir = 1;
                if (people.start_floor < people.end_floor)
                    dir = 1;
                else dir = 0;
                if (elevator.peoples.Count < elevator.max_pas && dir == elevator.direction_up){
                    elevator.Add_People(people);
                    peoples.RemoveAt(i);
                }
            }
        }
        Draw();
    }
    public void Move_up(){ elevator.Move_up(); Draw(); }
    public void Move_down(){ elevator.Move_down(); Draw(); }
    public int condition_1_table2(){ // Лифт выпускает на этаже?
        int res = 0;
        foreach (var people in elevator.peoples)
            if (elevator.current_floor == people.end_floor)
                return res = 1;
        return res;
    }
    public int condition_2_table2(){ // Лифт едет вверх?
        return elevator.direction_up;
    }
    public int condition_3_table2(){ // Лифт вызван вверх на этаже?
        int res = 0;
        foreach (var people in peoples)
            if (elevator.current_floor == people.start_floor)
                if (people.start_floor < people.end_floor && elevator.peoples.Count != elevator.max_pas)
                    return res = 1;
        return res;
    }
    public int condition_4_table2(){ // Лифт вызван ввниз на этаже?
        int res = 0;
        foreach (var people in peoples)
            if (elevator.current_floor == people.start_floor)
                if (people.start_floor > people.end_floor && elevator.peoples.Count != elevator.max_pas)
                    return res = 1;
        return res;
    }
    public int condition_1_table3(){ // Лифт едет вверх?
        return elevator.direction_up;
    }
    public int condition_2_table3(){ // Лифт вызван выше?
        int res = 0;
        foreach (var people in peoples)
            if (elevator.current_floor < people.start_floor)
                return res = 1;
        return res;
    }
    public int condition_3_table3(){ // Лифт выпускает выше?
        int res = 0;
        foreach (var people in elevator.peoples)
            if (elevator.current_floor < people.end_floor)
                return res = 1;
        return res;
    }
    public int condition_4_table3(){ // Лифт вызван ниже?
        int res = 0;
        foreach (var people in peoples)
            if (elevator.current_floor > people.start_floor)
                return res = 1;
        return res;
    }
    public int condition_5_table3(){ // Лифт выпускает ниже?
        int res = 0;
        foreach (var people in elevator.peoples)
            if (elevator.current_floor > people.end_floor)
                return res = 1;
        return res;
    }
    public int condition_1_table4(){ // Есть ли человек в лифте?
        if (elevator.peoples.Count > 0) return 1;
        else return 0;
    }
    public int condition_2_table4(){ // Нужный этаж?
        int res = 0;
        foreach (var people in elevator.peoples)
            if (elevator.current_floor == people.end_floor)
                return res = 1;
        return res;
    }
    public int condition_1_table5(){ // Есть ли челоек на этаже?
        int res = 0;
        foreach (var people in peoples)
            if (elevator.current_floor == people.start_floor)
                    return res = 1;
        return res;
    }
    public int condition_2_table5(){ // Лифт свободен?
        int res = 0;
        if (elevator.peoples.Count <= elevator.max_pas)
            return res = 1;
        return res;
    }
    public int condition_3_table5(){ // Человек едет вверх?
        int res = 0;
        foreach (var people in peoples)
            if (elevator.current_floor == people.start_floor && elevator.direction_up == 1)
                if (people.start_floor < people.end_floor)
                    return res = 1;
        return res;
    }
    public int condition_4_table5(){ // Лифт едет вверх?
        foreach (var people in peoples){
            if (people.start_floor >= elevator.current_floor && people.start_floor < people.end_floor && (elevator.peoples.Count == 0))
                elevator.direction_up = 1;
            else if (people.start_floor <= elevator.current_floor && people.start_floor > people.end_floor && (elevator.peoples.Count == 0))
                elevator.direction_up = 0;
        }
        return elevator.direction_up;
    }
    void randpeople(object sender, EventArgs e){
        Random random = new Random();
        int rand1, rand2, rand3;
        do{
        rand1 = random.Next(0, 8);
        rand2 = random.Next(0, 8);
        } while (rand1 == rand2);
        rand3 = random.Next(0, 2);
        peoples.Add(new People(rand1, rand2, rand3));
    }
    MyHookClass simpr;
    public Form1()
    {
        InitializeComponent();
        simpr = new MyHookClass(this);
        peoples = new List<People>();
        elevator = new Elevator(0, 3, 1);
        peoples.Add(new People(0, 6, 0));
        peoples.Add(new People(0, 2, 0));
        peoples.Add(new People(0, 2, 1));
        peoples.Add(new People(2, 6, 1));
        peoples.Add(new People(2, 7, 1));
        peoples.Add(new People(0, 3, 0));
        peoples.Add(new People(4, 0, 1));
        peoples.Add(new People(6, 5, 0));
        peoples.Add(new People(6, 7, 1));
        peoples.Add(new People(0, 4, 1));
        imgElevator = Image.FromFile("C:/Users/diman/Desktop/Elevator/Elevator/MyWinFormsApp/img/elevator.png");
        man         = Image.FromFile("C:/Users/diman/Desktop/Elevator/Elevator/MyWinFormsApp/img/man.png");
        badman      = Image.FromFile("C:/Users/diman/Desktop/Elevator/Elevator/MyWinFormsApp/img/badman.png");
        up          = Image.FromFile("C:/Users/diman/Desktop/Elevator/Elevator/MyWinFormsApp/img/buttons_up.png");
        down        = Image.FromFile("C:/Users/diman/Desktop/Elevator/Elevator/MyWinFormsApp/img/buttons_down.png");
        buttons     = Image.FromFile("C:/Users/diman/Desktop/Elevator/Elevator/MyWinFormsApp/img/buttons.png");
        updown      = Image.FromFile("C:/Users/diman/Desktop/Elevator/Elevator/MyWinFormsApp/img/buttons_up_down.png");
        Draw();
    }
    void StopButton_Click(object sender, EventArgs e){ stop = 1; }
    void ShowMessage(object sender, EventArgs e)
    {
        string message = "Офисный лифт\nCopyright 2023 Нехоченинов Д.А.\nНациональный исследовательский университет 'МЭИ'\nИнститут информационных и вычислительных технологий\nКафедра прикладной математики и искусственного интеллекта";
        string caption = "О программе";
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        MessageBoxIcon icon = MessageBoxIcon.Information;

        MessageBox.Show(message, caption, buttons, icon);
    }
    void Draw(){
        Bitmap resultImage = new Bitmap(800, 800);
        using (Graphics g = Graphics.FromImage(resultImage)){
            Pen pen = new Pen(Color.Black, 5); Point startPoint = new Point(125, 0); Point endPoint   = new Point(125, 800);
            g.DrawLine(pen, startPoint, endPoint); int interval = 90;
            for (int y = 28; y < 800; y += interval) { startPoint = new Point(125, y); endPoint = new Point(800, y); g.DrawLine(pen, startPoint, endPoint); }
            g.DrawImage(imgElevator, new Rectangle(1, 28 + (7-elevator.current_floor)*90, 120, 90));
            int[] dxs = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach(var people in peoples){
                if (people.bad == 1) { g.DrawImage(badman, new Rectangle(150 + dxs[people.start_floor], 50 + (7-people.start_floor)*90, 30, 60)); dxs[people.start_floor] += 30; }
                else { g.DrawImage(man, new Rectangle(150 + dxs[people.start_floor], 50 + (7-people.start_floor)*90, 30, 60)); dxs[people.start_floor] += 30; }
            }
            int dx = 18;
            foreach(var people in elevator.peoples){
                if (people.bad == 1) { g.DrawImage(badman, new Rectangle(dx, 50 + (7-elevator.current_floor)*90, 30, 60)); dx += 30; }
                else { g.DrawImage(man, new Rectangle(dx, 50 + (7-elevator.current_floor)*90, 30, 60)); dx += 30; }
            }
            int[] uparr   = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] downarr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach(var people in peoples){
                if (people.start_floor < people.end_floor) uparr[people.start_floor] = 1;
                else downarr[people.start_floor] = 1;
            }
            for (int i = 0; i < 8; i ++){
                if (uparr[i] == downarr[i] && downarr[i] == 0) g.DrawImage(buttons, new Rectangle(130, 60 + (7-i)*90, 15, 30));
                else if (uparr[i] > downarr[i]) g.DrawImage(up, new Rectangle(130, 60 + (7-i)*90, 15, 30));
                else if (uparr[i] < downarr[i]) g.DrawImage(down, new Rectangle(130, 60 + (7-i)*90, 15, 30));
                else g.DrawImage(updown, new Rectangle(130, 60 + (7-i)*90, 15, 30));
            }
            Font font = new Font("Arial", 24);
            Brush brush = new SolidBrush(Color.Black);
            for (int i = 0; i < 8; i ++){
                g.DrawString((i+1).ToString(), font, brush, 350, 60 + (7-i)*90);
            }
            pen.Dispose(); g.Dispose();
        }
        pictureBox1.Image = resultImage; 
    }
}