using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQLitePerformanceTest
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			string personalDirectoryPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			AppDomain.CurrentDomain.SetData("DataDirectory", personalDirectoryPath);

			Console.WriteLine("SQLiteデータベースファイルの初期化を行います。");
			InitializeDatabase();
			Console.WriteLine("初期化が完了しました。");

			InitializeComponent();
		}


		/// <summary>
		/// データベースの初期化を行う
		/// </summary>
		void InitializeDatabase()
		{
			string sqltext = "";
			System.Reflection.Assembly assm = System.Reflection.Assembly.GetExecutingAssembly();
			using (var stream = assm.GetManifestResourceStream("SQLitePerformanceTest.Assets.Sql.sqltest.txt"))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					sqltext = reader.ReadToEnd();
				}
			}

			using (var @dbc = new MyDbContext())
			{
				@dbc.Database.ExecuteSqlCommand(sqltext);
				@dbc.SaveChanges();
			}
		}
	}
}
