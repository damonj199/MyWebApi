using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using MyWebApi.Business.IServices;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;
using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;
using Serilog;

namespace MyWebApi.Business.Services;

public class OrderServices : IOrderServices
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly ILogger _logger = Log.ForContext<OrderServices>();
    private readonly IMapper _mapper;
    public OrderServices(IOrdersRepository ordersRepository, IMapper mapper)
    {
        _ordersRepository = ordersRepository;
        _mapper = mapper;
    }

    public List<OrderDto> GetOrders() => _ordersRepository.GetOrders();

    public OrderDto GetOrderById(Guid id)
    {
        if (id == Guid.Empty)
            throw new FileNotFoundException($"Заказа с id {id} не существует!");

        var order = _ordersRepository.GetOrderById(id);

        OrderResponse response = new OrderResponse()
        {
            Id = order.Id,
            UserName = order.UserName,
            Data = order.Data,
            Summa = order.Summa
        };
        return (order);
    }

    public void DeleteOrderyId(Guid id)
    {
        var order = _ordersRepository.GetOrderById(id);

        if (order == null)
        {
            throw new Exception("Oшибка удаления заказа");
        }
        _ordersRepository.DeleteOrderById(order);
    }

    public Guid CreateOrder(CreateOrderRequest request)
    {
        _logger.Information($"Добавляем заказ - {request.UserName}, на сумму: {request.Summa}");

        OrderDto order = _mapper.Map<OrderDto>(request);
         
        return _ordersRepository.CreateOrder(order);
    }

    public Guid UpdateOrder(UpdateOrderRequest request)
    {
        var order = _ordersRepository.GetOrderById(request.Id);
        
        if (order == null)
        {
            _logger.Information($"Заказ с id {request.Id} не найден!");
            return Guid.Empty;
        }

        order.UserName = request.UserName;
        order.Data = request.Date;
        order.Summa = request.Summa;

        return _ordersRepository.UpdateOrder(order);
    }
}