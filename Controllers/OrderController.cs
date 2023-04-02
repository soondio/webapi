using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplicationLab2.Models1;
using Microsoft.AspNetCore.Cors;

namespace WebApplicationLab2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CompClubWebContext _context;
        public OrdersController(CompClubWebContext context)
        {
            _context = context;
            //if (!_context.Orders.Any())
            //{
            //    _context.Orders.Add(new Order
            //    {
            //        TotalPrice = 100,
            //        Date=DateTime.Now
            //    });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrder()
        {
            var orders = await _context.Orders
                                        .Include(o => o.Client)
                                        .ToListAsync();

            var orderDtos = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                TotalPrice = o.TotalPrice,
                ComputerId=o.ComputerId,
                StartTime = o.Date,
                Client = new ClientDto
                {
                    Id = o.Client.Id,
                    Name = o.Client.Name,
                    Email = o.Client.Email,
                }
            });

            return Ok(orderDtos);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Order;
        }
   
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            // Проверяем, что такой клиент и компьютер существуют в базе данных
            var clientExists = await _context.Clients.AnyAsync(c => c.Id == orderDto.ClientId);
            var computerExists = await _context.Computers.AnyAsync(c => c.Id == orderDto.ComputerId);

            if (!clientExists || !computerExists)
            {
                return BadRequest("Клиент или компьютер не найден в базе данных");
            }

            // Получаем клиента по его id
            var client = await _context.Clients
                .Include(c => c.Orders) // загружаем заказы клиента
                .FirstOrDefaultAsync(c => c.Id == orderDto.ClientId);

            // Создаем новый заказ на основе переданных данных
            var order = new Order
            {
                Id = orderDto.Id+4,
                Client = client, // присваиваем клиента заказу
                ComputerId = orderDto.ComputerId,
                TotalPrice = orderDto.TotalPrice,
                Date = orderDto.StartTime,
                EndDate = orderDto.EndTime
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            _context.Entry(order).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order= await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}