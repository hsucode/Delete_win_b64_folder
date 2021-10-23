using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete_win_b64
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path3 = System.IO.Directory.GetCurrentDirectory();
            //Console.Write("请输入要查询的目录:");
            //string dir = Console.ReadLine();
            getDirectory(path3);

            //try
            //{
            //    ListFiles(new DirectoryInfo(dir));
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Console.ReadKey();
        }

        public static void ListFiles(FileSystemInfo info)
        {
            if (!info.Exists) return;

            DirectoryInfo dir = info as DirectoryInfo;
            //不是目录
            if (dir == null) return;

            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                //是文件
                if (file != null)
                    //Console.WriteLine(file.FullName + "\t " + file.Length);
                    Console.WriteLine(file.FullName + "\t ");
                //对于子目录，进行递归调用
                else
                    ListFiles(files[i]);

            }
        }


        //获得指定路径下所有子目录名
        public static void getDirectory( string path)
        {
          
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories())
            {         
                getDirectory(d.FullName);
                //Console.WriteLine("文件夹：" + d.FullName);

                //删除文件夹
                if (d.Name == "win_b64")
                {
                    Directory.Delete(d.FullName, true);
                    Console.WriteLine("删除文件夹：" + d.FullName);
                }
            }
        }

    }

}

