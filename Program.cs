string path = @"C:\Projetos\Back-End\CSharp\ProjetosPessoais\ComparadorDeArquivos\Arquivos\";
string arquivo1 = "Sudeste.csv";
string arquivo2 = "Sudeste2.csv";
List<string> lstArquivo1 = new();
List<string> lstArquivo2 = new();

using (StreamReader sr1 = File.OpenText($@"{path}\{arquivo1}"))
{
    sr1.ReadLine();
    while (!sr1.EndOfStream)
    {
        string? line = sr1.ReadLine();
        lstArquivo1.Add(line);
    }
}
lstArquivo1.Order();

using (StreamReader sr2 = File.OpenText($@"{path}\{arquivo2}"))
{
    sr2.ReadLine();
    while (!sr2.EndOfStream)
    {
        string? line = sr2.ReadLine();
        lstArquivo2.Add(line);
    }
}
lstArquivo2.Order();

IEnumerable<string> lstDiferenca = from regiao in lstArquivo1.Except(lstArquivo2)
                                   select regiao;

if (lstDiferenca.Any())
    foreach (string line in lstDiferenca)
        Console.WriteLine(line);
else
    Console.WriteLine($"Os arquivos {arquivo1} e {arquivo2} são iguais");

Console.WriteLine("Fim");