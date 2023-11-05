using APIClaudioStore.Data;
using APIClaudioStore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace APIClaudioStore.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> BuscarPorIdAsync(int id)
        {
            var resultado = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            return resultado;
        }

        public async Task<Produto> ComprarProdutoAsync(ComprarProduto comprarProduto)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == comprarProduto.Id);
            if (produto != null && produto.Estoque > 0)
            {
                produto.Estoque -= comprarProduto.Quantidade;
                await _context.SaveChangesAsync();
            }
            
            return produto;
        }

        public async Task<IEnumerable<Produto>> PegarTodosProdutosAsync()
        {
            var resultado = await _context.Produtos.ToListAsync();

            return resultado;
        }


        public async Task<IEnumerable<Produto>> SearchAsync(string search)
        {
            var resultado = await _context.Produtos.FromSqlRaw("SELECT * FROM Produtos WHERE Nome COLLATE SQL_Latin1_General_CP1_CI_AI LIKE ('%' + @search + '%')",
                new SqlParameter("@search", search)).ToListAsync();

            return resultado;
        }

    }
}
