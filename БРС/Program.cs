using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*https://www.iconfinder.com/search?q=lock&price=free *///ссылка для скачивания иконок и картинок
namespace БРС
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Variation());//надо бы что-то тут поменять , ибо он стартует с вариации и не закрывается на других 
            
               

        }
    }
}
