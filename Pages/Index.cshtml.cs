using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;


public class IndexModel : PageModel
{
    [BindProperty]
    public int Quantidade { get; set; } = 1;

    public List<string> Resultados { get; set; } = new();

    public void OnPost()
    {
        for (int i = 1; i <= Quantidade; i++)
        {
            var numeros = SortearNumeros(6, 60);
            Resultados.Add($"Sorteio {i}: {string.Join(" ", numeros)}");
        }
    }

    private List<int> SortearNumeros(int quantidade, int maximo)
    {
        Random random = new Random();
        HashSet<int> numeros = new HashSet<int>();

        while (numeros.Count < quantidade)
        {
            numeros.Add(random.Next(1, maximo + 1));
        }

        return numeros.OrderBy(n => n).ToList();
    }
}
