using OrderFlow.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Application.Interfaces
{
    public interface IPedidoService 
    {
        Task<PedidoResponse> CriarAsync(PedidoRequest request);
    }
}
