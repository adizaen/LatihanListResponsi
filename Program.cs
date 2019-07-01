using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanResponsiUAS
{
    class Program
    {
        static void Main(string[] args)
        {
            int pil;
            List<Mahasiswa> list = new List<Mahasiswa>();
            Console.Title = "Aplikasi Data";
            do
            {
                Console.WriteLine("Pilihan menu yang tersedia :");
                Console.WriteLine("1. Tambah data");
                Console.WriteLine("2. Edit data");
                Console.WriteLine("3. Hapus data");
                Console.WriteLine("4. Cari data");
                Console.WriteLine("5. Tampilkan data");
                Console.WriteLine("6. Keluar");
                Console.Write("\nPilihan anda [1..6] : ");
                pil = Convert.ToInt32(Console.ReadLine());

                switch (pil)
                {
                    case 1:
                        Tambah(list);
                        break;
                    case 2:
                        Edit(list);
                        break;
                    case 3:
                        Hapus(list);
                        break;
                    case 4:
                        Cari(list);
                        break;
                    case 5:
                        Tampil(list);
                        break;
                    default:
                        Console.WriteLine("Maaf, nomor tidak valid!\n");
                        break;
                }
            } while (pil != 6);
        }

        static void Tambah(List<Mahasiswa> list)
        {
            Console.WriteLine("Silahkan isi data berikut!");
            Console.Write("NIM            : ");
            string nim = Console.ReadLine().ToString();
            Console.Write("Nama Mahasiswa : ");
            string nama = Console.ReadLine().ToString();

            list.Add(new Mahasiswa { Nim = nim, NamaMhs = nama });
            Console.WriteLine();
        }

        static void Edit(List<Mahasiswa> list)
        {
            Console.Write("\nInputkan NIM : ");
            string nim = Console.ReadLine().ToString();

            Mahasiswa mhs;
            mhs = list.SingleOrDefault(f => f.Nim == nim);

            Console.WriteLine("Data awal!");
            Console.WriteLine("NIM    : {0}", mhs.Nim);
            Console.WriteLine("Nama   : {0}", mhs.NamaMhs);
            Console.WriteLine();

            Console.WriteLine("Data diedit");
            Console.Write("Input nama baru   : ");
            string nama = Console.ReadLine().ToString();
            mhs.NamaMhs = nama;
            Console.WriteLine();
        }

        static void Hapus(List<Mahasiswa> list)
        {
            Console.WriteLine("\nHapus berdasarkan : ");
            Console.WriteLine("1. NIM");
            Console.WriteLine("2. Nama Mahasiswa");
            Console.Write("\nPilihan anda : ");
            int pil = Convert.ToInt32(Console.ReadLine());

            switch(pil)
            {
                case 1:
                    Console.Write("Inputkan NIM : ");
                    string nim = Console.ReadLine().ToString();
                    list.Remove(list.SingleOrDefault(f=>f.Nim == nim));
                    break;
                case 2:
                    Console.Write("Inputkan Nama : ");
                    string nama = Console.ReadLine().ToString();
                    List<Mahasiswa> Pencarian = list.Where(f => f.NamaMhs.Contains(nama)).ToList();
                    foreach(Mahasiswa mhs in Pencarian)
                    {
                        list.Remove(mhs);
                    }
                    break;
                default:
                    Console.WriteLine("Maaf, nomor tidak valid!");
                    break;
            }
        }

        static void Cari(List<Mahasiswa> list)
        {
            Console.WriteLine("\nCari berdasarkan : ");
            Console.WriteLine("1. NIM");
            Console.WriteLine("2. Nama Mahasiswa");
            Console.Write("\nPilihan anda : ");
            int pil = Convert.ToInt32(Console.ReadLine());
            
            switch (pil)
            {
                case 1:
                    Console.Write("Inputkan NIM : ");
                    string nim = Console.ReadLine().ToString();

                    Mahasiswa mhs;
                    mhs = list.SingleOrDefault(f => f.Nim == nim);
                    Console.WriteLine("\n--------------------------");
                    Console.WriteLine("{0}\t{1}", mhs.Nim, mhs.NamaMhs);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Write("Inputkan Nama : ");
                    string nama = Console.ReadLine().ToString();

                    List<Mahasiswa> Pencarian = list.Where(f => f.NamaMhs.Contains(nama)).ToList();
                    Console.WriteLine("\n--------------------------");
                    foreach (Mahasiswa mhs1 in Pencarian)
                    {
                        Console.WriteLine("{0}\t{1}", mhs1.Nim, mhs1.NamaMhs);
                    }
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Maaf, nomor tidak valid!");
                    break;
            }
        }

        static void Tampil(List<Mahasiswa> list)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Nim\t\tNama");
            Console.WriteLine("----------------------------");
            foreach (Mahasiswa mhs in list)
            {
                Console.Write("{0}\t{1}", mhs.Nim, mhs.NamaMhs);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
