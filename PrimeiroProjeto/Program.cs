//Screen Sound
using System.Diagnostics;
String mensagemDeBoasVindas = "Bem vindo(a) ao Screen Sound!";
//List<string> ListaDeBandas = new List<string>();
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
//um dicionário que é uma coleção de pares chave-valor, onde cada chave é única e associada a um valor correspondente. É uma estrutura de dados útil para armazenar informações relacionadas que precisam ser acessadas com base em uma chave específica


void ExibirLogo()
{
    Console.WriteLine(@"
▒█▀▀▀█ █▀▀ █▀▀█ █▀▀ █▀▀ █▀▀▄ 　 ▒█▀▀▀█ █▀▀█ █░░█ █▀▀▄ █▀▀▄ 
░▀▀▀▄▄ █░░ █▄▄▀ █▀▀ █▀▀ █░░█ 　 ░▀▀▀▄▄ █░░█ █░░█ █░░█ █░░█ 
▒█▄▄▄█ ▀▀▀ ▀░▀▀ ▀▀▀ ▀▀▀ ▀░░▀ 　 ▒█▄▄▄█ ▀▀▀▀ ░▀▀▀ ▀░░▀ ▀▀▀░ 
");
   
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite algum número de sua escolha!");
    Console.WriteLine("1 - Para registrar uma banda");
    Console.WriteLine("2 - Para mostrar todas as bandas");
    Console.WriteLine("3 - Para avaliar uma banda");
    Console.WriteLine("4 - Para Exibir a média de uma banda");
    Console.WriteLine("0 - Para sair");
    Console.Write("\nSua opção: ");
    String Opcao = Console.ReadLine()!;
    int OpcaoNumero = int.Parse(Opcao);

    switch (OpcaoNumero)
    {
        case 1: RegistrarBanda();
            Console.WriteLine("Você escolheu a opção " + OpcaoNumero);
            break;
        case 2: MostrarBandasRegistradas();
            Console.WriteLine("Você escolheu a opção " + OpcaoNumero);
            break;
        case 3: AvaliarUmaBanda();
            Console.WriteLine("Você escolheu a opção " + OpcaoNumero);
            break;
        case 4: MediaDaBanda();
            Console.WriteLine("Você escolheu a opção " + OpcaoNumero);
            break;
        case 0:
            Console.WriteLine("Você escolheu a opção " + OpcaoNumero);
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("\nDigite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(3000);
    Console.Clear();
    ExibirMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Mostrar todas as bandas registradas");
    //for (int i = 0; i < ListaDeBandas.Count; i++)
    //{
    // Console.WriteLine($"Banda: {ListaDeBandas[i]}");
    //}
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite alguma tecla para voltar ao menu principal\n");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();

}

void ExibirTituloDaOpcao (string titulo)
{
    int quantidadeDeLetra = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetra, '-');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digitar qual banda gostaria de avaliar 
    //Ver se a banda existe no dicionario e depois atribuir uma nota 
    //senão volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma banda");
    Console.Write("Digite o nome da banda que gostaria de avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual nota a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota); //utilizamos os colchetes para indexar o dicionário bandasRegistradas, usando a chave. Com essa construção, nós acessamos os valores, que é uma lista de números inteiros. Por isso, podemos acionar diretamente o método Add() para inserir a nota.
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

void MediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média da banda");
    Console.Write("Qual banda você gostaria de ver a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        //double mediaDaBanda = bandasRegistradas[nomeDaBanda].Average();
        //Console.WriteLine($"\nA média da banda {nomeDaBanda} é de {mediaDaBanda}");
        List<int> notasDasBandas = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"A média da banda {nomeDaBanda} é {notasDasBandas.Average()}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }

}

ExibirMenu();
