using System.Runtime.InteropServices.Marshalling;

class Buku
{
    public int ID { get; set; }
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public int TahunTerbit { get; set; }
    public bool status { get; set; } = true;
    public void Masukkaninfo()
    {
        Console.WriteLine($"ID: {ID}, Judul: {Judul}, Penulis: {Penulis}, Tebit: {TahunTerbit}, Status: {(status ? "Tersedia" : "Dipinjam")}");
    }
}

class Perpustakaan 
{
    public string Nama {  get; set; }
    public string Alamat {  get; set; }
    private List<Buku> KoleksiBuku = new List<Buku>();
    public void TambahBuku(Buku buku)
    {
        buku.ID = KoleksiBuku.Count + 1;
        KoleksiBuku.Add(buku);
        Console.WriteLine("Buku berhasil ditambahkan");
    }
    public void TunjukanSemuaBuku()
    {
        Console.WriteLine("Daftar Buku:");
        foreach (var buku in KoleksiBuku)
        {
            buku.Masukkaninfo();
        }
    }
    public Buku CariBuku(int id)
    {
        return KoleksiBuku.Find(b => b.ID == id);
    }

    public void UbahBuku(int id, string Judul, String Penulis, int TahunTerbit)
    {
        var buku = CariBuku(id);
        if (buku != null)
        {
            buku.Judul = Judul;
            buku.Penulis = Penulis;
            buku.TahunTerbit = TahunTerbit;
            Console.WriteLine("Buku berhasil diupdate");
        }
        else
        {
            Console.WriteLine("Buku tidak ada");
        }
    }
    public void HapusBuku(int id)
    {
        var buku = CariBuku(id);
        if (buku != null)
        {
            KoleksiBuku.Remove(buku);
            Console.WriteLine("Buku berhasil dihapus");
        }
        else
        {
            Console.WriteLine("Buku gagal ditemukan");
        }
    }
} 

class Program
{
    static void Main(string[] args)
    {
        Perpustakaan perpustakaan = new Perpustakaan { Nama = "Perpustakaan Unej", Alamat = "Jalan Kalimantan" };
        while (true)
        {
            Console.WriteLine("\n Menu; ");
            Console.WriteLine("1. Tambah Buku");
            Console.WriteLine("2. Tampilkan Semua Buku");
            Console.WriteLine("3. Ubah Buku");
            Console.WriteLine("4. Hapus Buku");
            Console.WriteLine("5. Keluar");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Buku bukuBaru = new Buku();
                    Console.Write("Masukkan Judul: ");
                    bukuBaru.Judul = Console.ReadLine();
                    Console.Write("Masukkan Penulis: ");
                    bukuBaru.Penulis = Console.ReadLine();
                    Console.Write("Masukkan Tahun Terbit: ");
                    bukuBaru.TahunTerbit = int.Parse(Console.ReadLine());
                    perpustakaan.TambahBuku(bukuBaru);
                    break;
                case "2":
                    perpustakaan.TunjukanSemuaBuku();
                    break;
                case "3":
                    Console.Write("Masukkan ID Buku yang ingin diubah: ");
                    int idUbah = int.Parse(Console.ReadLine());
                    Console.Write("Masukkan Judul Baru: ");
                    string judulBaru = Console.ReadLine();
                    Console.Write("Masukkan Penulis Baru: ");
                    string penulisBaru = Console.ReadLine();
                    Console.Write("Masukkan Tahun Terbit Baru: ");
                    int tahunBaru = int.Parse(Console.ReadLine());
                    perpustakaan.UbahBuku(idUbah, judulBaru, penulisBaru, tahunBaru);
                    break;
                case "4":
                    Console.Write("Masukkan ID Buku yang ingin dihapus: ");
                    int idHapus = int.Parse(Console.ReadLine());
                    perpustakaan.HapusBuku(idHapus);
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;

            }
        }
    }
}