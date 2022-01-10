namespace lab4_ex4
{
    public partial class Form1 : Form
    {
        List<Vehicle> vehiclesList = new List<Vehicle>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.vehiclesList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2 (ну остаток от деления на 3)
                {
                    case 0: // если 0, то велосипед
                        this.vehiclesList.Add(Bike.Generate());
                        break;
                    case 1: // если 1 то машина
                        this.vehiclesList.Add(Car.Generate());
                        break;
                    case 2: // если 2 то самолет
                        this.vehiclesList.Add(Air.Generate());
                        break;
                        // появление других чисел маловероятно
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            // заведем счетчики под каждый тип
            int bikesCount = 0;
            int carsCount = 0;
            int airsCount = 0;

            // пройдемся по всему списку
            foreach (var vehicle in this.vehiclesList)
            {
                // помните, что в списки у нас лежат фрукты,
                // то есть объекты типа Fruit
                // поэтому чтобы проверить какой именно фрукт
                // мы в данный момент обозреваем, мы используем ключевое слово is
                if (vehicle is Bike) // читается почти как чистый инглиш, "если fruit есть Мандарин"
                {
                    bikesCount += 1;
                }
                else if (vehicle is Car)
                {
                    carsCount += 1;
                }
                else if (vehicle is Air)
                {
                    airsCount += 1;
                }
            }

            // а ну и вывести все это надо на форму
            txtInfo.Text = "Велоcипеды\tАвтомобили\tСамолеты"; // буквы экнмлю, чтобы влезло на форму
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", bikesCount, carsCount, airsCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.vehiclesList.Count == 0)
            {
                txtOut.Text = "Автомат пуст.";
                return;
            }

            // взяли первый фрукт
            var vehicle = this.vehiclesList[0];
            // тут вам не реальность, взятие это на самом деле создание указателя на область в памяти
            // где хранится экземпляр класса, так что если хочешь удалить, делай это сам
            this.vehiclesList.RemoveAt(0);

            txtOut.Text = vehicle.GetInfo();

            // обновим информацию о количестве товара на форме
            ShowInfo();
        }
    }
}