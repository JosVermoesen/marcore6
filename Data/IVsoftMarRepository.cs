using System.Collections.Generic;
using System.Threading.Tasks;
using marcore.Entities;
using marcore.api.Helpers;
// 

namespace marcore.api.Data
{
    public interface IVsoftMarRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<PagedList<VsoftCustomer>> GetVsoftCustomers(CustomerParams customerParams);
        Task<PagedList<VsoftCustomer>> GetVsoftCustomersWithMail();        
        Task<VsoftCustomer> GetVsoftCustomer(string id);
        Task<bool> CustomerExistsAsync(string id);
        Task<VsoftCustomer> CustomerNew(VsoftCustomer customer);
        Task<IEnumerable<VsoftCustomerInvoice>> GetVsoftCustomerInvoices();
        Task<VsoftCustomerInvoice> GetVsoftCustomerInvoice(string id);
        Task<IEnumerable<VsoftContract>> GetVsoftContracts();
        Task<VsoftContract> GetVsoftContract(string id);
        Task<IEnumerable<VsoftTelebibContract>> GetVsoftTelebibContracts();
        Task<VsoftTelebibContract> GetVsoftTelebibContract(int id);


        Task<PagedList<VsoftSupplier>> GetVsoftSuppliers(SupplierParams supplierParams);
        Task<VsoftSupplier> GetVsoftSupplier(string id);
        Task<bool> SupplierExistsAsync(string id);
        Task<VsoftSupplier> SupplierNew(VsoftSupplier supplier);
        Task<IEnumerable<VsoftSupplierInvoice>> GetVsoftSupplierInvoices();
        Task<VsoftSupplierInvoice> GetVsoftSupplierInvoice(string id);


        Task<PagedList<VsoftLedgerAccount>> GetVsoftLedgerAccounts(AccountParams accountParams);
        Task<VsoftLedgerAccount> GetVsoftLedgerAccount(string id);
        Task<bool> AccountExistsAsync(string id);
        Task<VsoftLedgerAccount> AccountNew(VsoftLedgerAccount vsoftaccount);



        Task<PagedList<VsoftMailform>> GetVsoftMailforms(MailformParams mailformParams);
        Task<VsoftMailform> GetVsoftMailform(string id);
        Task<bool> MailformExistsAsync(string id);
        Task<VsoftMailform> MailformNew(VsoftMailform mailform);

    }
}
