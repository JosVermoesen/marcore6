using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marcore.Entities;
using marcore.api.Helpers;
// 
using Microsoft.EntityFrameworkCore;

namespace marcore.api.Data
{
    public class VsoftMarRepository : IVsoftMarRepository
    {
        private readonly DataContext _context;

        public VsoftMarRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        public async Task<VsoftSupplier> SupplierNew(VsoftSupplier supplier)
        {
            await _context.VsoftSuppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();

            return supplier;
        }

        public async Task<VsoftSupplier> GetVsoftSupplier(string id)
        {
            var vsoftsupplier = await _context.VsoftSuppliers
                .Include(i => i.VsoftSupplierInvoices)
                .FirstOrDefaultAsync(vs => vs.Id == id);

            return vsoftsupplier;
        }

        public async Task<PagedList<VsoftSupplier>> GetVsoftSuppliers(SupplierParams supplierParams)
        {
            var vsoftsuppliers = _context.VsoftSuppliers.OrderBy(vs => vs.Id).AsQueryable();

            if (supplierParams.MinA107 != "" || supplierParams.MaxA107 != "zzzzzz")
            {
                vsoftsuppliers = vsoftsuppliers.Where(vs => string.Compare(vs.A107, supplierParams.MinA107) >= 0 && string.Compare(vs.A107, supplierParams.MaxA107) <= 0);
            }

            return await PagedList<VsoftSupplier>.CreateAsync(vsoftsuppliers, supplierParams.PageNumber, supplierParams.PageSize);
        }

        public async Task<VsoftSupplierInvoice> GetVsoftSupplierInvoice(string id)
        {
            var vsoftsupplierinvoice = await _context.VsoftSupplierInvoices.FirstOrDefaultAsync(vsi => vsi.Id == id);
            return vsoftsupplierinvoice;
        }

        public async Task<IEnumerable<VsoftSupplierInvoice>> GetVsoftSupplierInvoices()
        {
            var vsoftsupplierinvoices = await _context.VsoftSupplierInvoices.ToListAsync();
            return vsoftsupplierinvoices;
        }



        public async Task<VsoftLedgerAccount> AccountNew(VsoftLedgerAccount vsoftaccount)
        {
            await _context.VsoftLedgerAccounts.AddAsync(vsoftaccount);
            await _context.SaveChangesAsync();

            return vsoftaccount;
        }
        public async Task<VsoftLedgerAccount> GetVsoftLedgerAccount(string id)
        {
            var vsoftaccount = await _context.VsoftLedgerAccounts.Include(d => d.VsoftLedgers).FirstOrDefaultAsync(va => va.Id == id);
            return vsoftaccount;
        }

        public async Task<PagedList<VsoftLedgerAccount>> GetVsoftLedgerAccounts(AccountParams accountParams)
        {
            var vsoftaccounts = _context.VsoftLedgerAccounts.OrderBy(va => va.Id).AsQueryable();

            if (accountParams.MinV020 != "" || accountParams.MaxV020 != "zzzzzz")
            {
                // vsoftcustomers =  vsoftcustomers.Where(vc => vc.A107 >= customerParams.MinA107 && vc.A107 <= customerParams.MaxA107);
                vsoftaccounts = vsoftaccounts.Where(va => string.Compare(va.V020, accountParams.MinV020) >= 0 && string.Compare(va.V020, accountParams.MaxV020) <= 0);
            }

            return await PagedList<VsoftLedgerAccount>.CreateAsync(vsoftaccounts, accountParams.PageNumber, accountParams.PageSize);
        }



        public async Task<VsoftCustomer> CustomerNew(VsoftCustomer customer)
        {
            await _context.VsoftCustomers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<VsoftCustomer> GetVsoftCustomer(string id)
        {
            var vsoftcustomer = await _context.VsoftCustomers
                .Include(c => c.VsoftContracts)
                .Include(i => i.VsoftCustomerInvoices)
                .FirstOrDefaultAsync(vc => vc.Id == id);

            return vsoftcustomer;
        }

        public async Task<PagedList<VsoftCustomer>> GetVsoftCustomers(CustomerParams customerParams)
        {
            var vsoftcustomers = _context.VsoftCustomers.OrderBy(vc => vc.Id).AsQueryable();

            if (customerParams.MinA107 != "" || customerParams.MaxA107 != "zzzzzz")
            {
                // vsoftcustomers =  vsoftcustomers.Where(vc => vc.A107 >= customerParams.MinA107 && vc.A107 <= customerParams.MaxA107);
                vsoftcustomers = vsoftcustomers.Where(vc => string.Compare(vc.A107, customerParams.MinA107) >= 0 && string.Compare(vc.A107, customerParams.MaxA107) <= 0);
            }

            return await PagedList<VsoftCustomer>.CreateAsync(vsoftcustomers, customerParams.PageNumber, customerParams.PageSize);
        }

        public async Task<PagedList<VsoftCustomer>> GetVsoftCustomersWithMail()
        {
            var vsoftcustomers = _context.VsoftCustomers
                .Where(x => x.V224 != "")
                .OrderBy(vc => vc.A100).AsQueryable();

            return await PagedList<VsoftCustomer>.CreateAsync(vsoftcustomers, 1, 2000);
        }

        public async Task<VsoftContract> GetVsoftContract(string id)
        {
            // var vsoftcontract = await _context.VsoftContracts.FirstOrDefaultAsync(vc => vc.Id == id);            
            var vsoftcontract = await _context.VsoftContracts
               .Include(i => i.VsoftTelebibContracts)
               .FirstOrDefaultAsync(vc => vc.Id == id);

            return vsoftcontract;
        }

        public async Task<VsoftCustomerInvoice> GetVsoftCustomerInvoice(string id)
        {
            var vsoftcustomerinvoice = await _context.VsoftCustomerInvoices.FirstOrDefaultAsync(vci => vci.Id == id);
            return vsoftcustomerinvoice;
        }

        public async Task<IEnumerable<VsoftCustomerInvoice>> GetVsoftCustomerInvoices()
        {
            var vsoftcustomerinvoices = await _context.VsoftCustomerInvoices.ToListAsync();
            return vsoftcustomerinvoices;
        }

        public async Task<IEnumerable<VsoftContract>> GetVsoftContracts()
        {
            var vsoftcontracts = await _context.VsoftContracts.ToListAsync();
            return vsoftcontracts;
        }

        public async Task<VsoftTelebibContract> GetVsoftTelebibContract(int id)
        {
            var vsofttelebibcontract = await _context.VsoftTelebibContracts.FirstOrDefaultAsync(vci => vci.Id == id);
            return vsofttelebibcontract;
        }

        public async Task<IEnumerable<VsoftTelebibContract>> GetVsoftTelebibContracts()
        {
            var vsofttelebibcontracts = await _context.VsoftTelebibContracts.ToListAsync();
            return vsofttelebibcontracts;
        }

        public async Task<VsoftMailform> MailformNew(VsoftMailform mailform)
        {
            await _context.VsoftMailforms.AddAsync(mailform);
            await _context.SaveChangesAsync();

            return mailform;
        }

        public async Task<VsoftMailform> GetVsoftMailform(string id)
        {
            var vsoftmailform = await _context.VsoftMailforms
                .FirstOrDefaultAsync(vm => vm.Id == id);

            return vsoftmailform;
        }

        public async Task<PagedList<VsoftMailform>> GetVsoftMailforms(MailformParams mailformParams)
        {
            var vsoftmailforms = _context.VsoftMailforms.OrderBy(vm => vm.Id).AsQueryable();

            if (mailformParams.MinId != "" || mailformParams.MaxId != "zzzzzz")
            {
                vsoftmailforms = vsoftmailforms.Where(vm => string.Compare(vm.Id, mailformParams.MinId) >= 0 && string.Compare(vm.Id, mailformParams.MaxId) <= 0);
            }

            return await PagedList<VsoftMailform>.CreateAsync(vsoftmailforms, mailformParams.PageNumber, mailformParams.PageSize);
        }




        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AccountExistsAsync(string id)
        {
            if (await _context.VsoftLedgerAccounts.AnyAsync(x => x.Id == id))
                return true;

            return false;
        }

        public async Task<bool> CustomerExistsAsync(string id)
        {
            if (await _context.VsoftCustomers.AnyAsync(x => x.Id == id))
                return true;

            return false;
        }

        public async Task<bool> SupplierExistsAsync(string id)
        {
            if (await _context.VsoftSuppliers.AnyAsync(x => x.Id == id))
                return true;

            return false;
        }
        public async Task<bool> MailformExistsAsync(string id)
        {
            if (await _context.VsoftMailforms.AnyAsync(x => x.Id == id))
                return true;

            return false;
        }
    }
}
