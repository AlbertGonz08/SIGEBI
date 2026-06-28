using SIGEBI.Domain.Entities.Usuario;
using SIGEBI.Domain.Repository;

public class UsuarioServicio
{
    private readonly IUsuarioRepository _usuarioRepo;

    public UsuarioServicio(IUsuarioRepository usuarioRepo)
    {
        _usuarioRepo = usuarioRepo;
    }

    public void RegistrarUsuario(Usuario usuario) => _usuarioRepo.Guardar(usuario);

    public Usuario ObtenerPorId(int id) => _usuarioRepo.ObtenerPorId(id);

    public Usuario ObtenerPorCedula(string cedula) => _usuarioRepo.ObtenerPorCedula(cedula);

    public IEnumerable<Usuario> Listar() => _usuarioRepo.Listar();
}