var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

SaladeAula bloco = new SaladeAula(4);

app.MapGet("/", () => bloco.listar());
app.MapGet("/entrar/{sala}", (string sala) => bloco.entrar(new Aluno(sala)));
app.MapGet("/sair/{sala}", (string sala) => bloco.sair(sala));
app.Run();

class Aluno
{
    public String sala;

    public Aluno(String sala)
    {
        this.sala = sala;
    }
}

class SaladeAula
{
  
    List<Aluno> integrados = new List<Aluno>();
    int capacidade;

    public SaladeAula(int capacidade)
    {
        this.capacidade = capacidade;
    }

    public String listar()
    {
        String alunos = "integrados:\n";

        foreach (Aluno aula in integrados)
        {
            alunos += aula.sala + "\n";
        }

        return alunos;

    }

    public String entrar(Aluno d)
    {
        
        if (integrados.Count < capacidade)
        {
            integrados.Add(d);
            return $"O aluno da sala {d.sala} entrou no bloco.";
        }
        else
        {
            return "Bloco completo";
        }
    }

    public String sair(String sala)
    {
        Aluno toRemove = null;

        foreach (Aluno aula in integrados)
        {
            if (aula.sala.Equals(sala))
            {
                toRemove = aula;
                break;
            }
        }

        if (toRemove != null)
        {
            integrados.Remove(toRemove);
            return $"O aluno {toRemove.sala} saiu do bloco.";
        }
        else
        {
            return "O aluno não se encontra no bloco.";
        }
    }


}