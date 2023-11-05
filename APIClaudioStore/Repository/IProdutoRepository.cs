using APIClaudioStore.Models;

namespace APIClaudioStore.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> PegarTodosProdutosAsync();
        Task<Produto> BuscarPorIdAsync(int id);
        Task<IEnumerable<Produto>> SearchAsync(string search);
        Task<Produto> ComprarProdutoAsync(ComprarProduto comprarProduto);
    }
}
