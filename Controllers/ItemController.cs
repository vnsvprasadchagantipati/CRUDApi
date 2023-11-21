using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CRUDApi.Database;
using CRUDApi.Dto;
using CRUDApi.Services;
using CRUDApi.Repository;
using Microsoft.AspNetCore.Authorization;
using CRUDApi.Entities;
using System.Security.Cryptography.X509Certificates;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;
        private  readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            this.itemService = itemService;
            _mapper = mapper;
        }
        [HttpGet, Route("GetAllItems")]
        [Authorize(Roles = "Supplier")]
        public IActionResult GetAll()
        {
            try
            {
                List<Item> items = itemService.getItems();
                List<ItemDto> itemDto = _mapper.Map<List<ItemDto>>(items); //converting enity to dto
                return StatusCode(200, itemDto); //here products details are sending in json format
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetItemsByItemCode/{itemCode}")]
        [Authorize(Roles = "Supplier")]
        public IActionResult GetByCode(string itemCode)
        {
            try
            {
                Item item = itemService.getItemByCode(itemCode);
                ItemDto itemDto = _mapper.Map<ItemDto>(item);
                if (item != null)
                    return StatusCode(200, item);
                else
                    return StatusCode(404, new JsonResult("Invalid name")); //convert string to Json use JsonResult class
                //return StatusCode(404,product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetItemsByItemName/{itemName}")]
        [Authorize(Roles = "User")]
        public IActionResult GetByName(string itemName)
        {
            try
            {
                Item item = itemService.getItemBYName(itemName);
                ItemDto itemDto = _mapper.Map<ItemDto>(item);
                if (item != null)
                    return StatusCode(200, item);
                else
                    return StatusCode(404, new JsonResult("Invalid itemNamme")); //convert string to Json use JsonResult class
                //return StatusCode(404,product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //POST /AddProduct
        
        [HttpPost, Route("AddItem")]
        [Authorize(Roles = "Supplier")]
        public IActionResult Add([FromBody] ItemDto itemDto)
        {
            try
            {
                Item item  = _mapper.Map<Item>(itemDto); //converting entity from dto
                itemService.Add(item);
                return StatusCode(200, item); //after successfully add product we return same product in json form
                //return Ok(); //return emplty result
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //Delete /DeleteItem/1
        [HttpDelete, Route("DeleteItem/{itemCode}")]
        [Authorize(Roles = "Supplier")]
        public IActionResult Delete(string itemCode)
        {
            try
            {
                itemService.Remove(itemCode);
                return StatusCode(200, new JsonResult($"Product with ItemCode {itemCode} is Deleted"));
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPut]
        [Authorize(Roles = "Supplier")]
        public IActionResult Put(ItemDto itemDto)

        {
            try
            {
                Item item = _mapper.Map<Item>(itemDto);
                itemService.Update(item);
                return StatusCode(200, item);
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
