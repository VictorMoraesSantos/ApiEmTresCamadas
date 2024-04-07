using DevIO.Business.Interfaces;

namespace DevIO.Business.Notificacoes;

public class Notificador : INotificador
{
    private readonly List<Notificacao> _notificacaos;

    public Notificador()
    {
        _notificacaos = new List<Notificacao>();
    }

    public void Handle(Notificacao notificacao)
    {
        _notificacaos.Add(notificacao);
    }

    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacaos;
    }

    public bool TemNotificacao()
    {
        return _notificacaos.Any();
    }
}