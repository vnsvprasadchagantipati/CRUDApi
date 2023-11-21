using AutoMapper;
using CRUDApi.Dto;
using CRUDApi.Entities;
using CRUDApi.Repository;
using CRUDApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;
        private readonly IMapper _mapper;

        public SupplierController(IMapper mapper, ISupplierService supplierService) 
        {
             _mapper = mapper;
            this.supplierService = supplierService;
        
        }

        [HttpPost]
        [Authorize(Roles = "Supplier")]
        public IActionResult Add(SupplierDto supplierDto)
        {

            try
            {
                Supplier supplier = _mapper.Map<Supplier>(supplierDto);
                supplierService.AddSupplier(supplier);
                return StatusCode(200, supplier);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Supplier")]
        public IActionResult Delete(string sulpNo)
            {
                try
                {
                    supplierService.RemoveSupplier(sulpNo);
                    return StatusCode(200, new JsonResult($"Product with ItemCode {sulpNo} is Deleted"));
                }
                catch (Exception)
                {

                    throw;
                }

            
              }




        [HttpGet]
        [Authorize(Roles = "Supplier")]
        public IActionResult Get(SupplierDto supplierDto)
        {
            try
            {
                List<Supplier> suppliers = supplierService.getSuppliers();
                List<SupplierDto> supplierDtos = _mapper.Map<List<SupplierDto>>(suppliers);
                return StatusCode(200, supplierDtos);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        [Authorize(Roles = "Supplier")]
        public IActionResult Put(SupplierDto supplierDto)

        {
            try
            {
                Supplier supplier = _mapper.Map<Supplier>(supplierDto);
                supplierService.updateSupplier(supplier);
                return StatusCode(200, supplier);
            }
            catch (Exception)
            {

                throw;
            }
        }

            
        }
    }

