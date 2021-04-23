/*Реализовать на Windows Forms приложение,
которое позволяет вести список задач.
БД создать с помощью подхода Code First.
Информация о задаче:
-заголовок
- описание
- срок выполнения
- автор
- приоритет.

Возможности:
-CRUD операции над списком задач, вся информация хранится в БД.

В задании применить механизмы ленивой, явной и безотложной загрузки.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagerCodeFirst
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
