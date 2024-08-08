using SAPbobsCOM;
using System;

namespace AddDocumentSbo.Services
{
    public class DocumentService
    {
        public void AddDocument(Company company)
        {
            try
            {
                var document = CreateDocument(company);

                company.StartTransaction();

                Add(company, document);

                if (company.InTransaction)
                    company.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
            }
            catch (Exception)
            {
                if (company.InTransaction)
                    company.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                throw;
            }
        }

        public Documents CreateDocument(Company company)
        {
            var document = company.GetBusinessObject(BoObjectTypes.oPurchaseOrders) as Documents;

            var currentDate = DateTime.Now.Date;
            document.BPL_IDAssignedToInvoice = 1;
            document.CardCode = "FOR000011";
            document.CardName = "SARDO ENGENHARIA LTDA";
            document.TaxDate = currentDate;
            document.DocDueDate = currentDate;
            document.DocType = BoDocumentTypes.dDocument_Items;
            document.Comments = "Teste";

            document.Lines.ItemCode = "DOP000002";
            document.Lines.ItemDescription = "ITEM PARA TESTE";
            document.Lines.Quantity = 1.00;
            document.Lines.UnitPrice = 1;
            //document.Lines.Usage = "4";

            return document;
        }

        public void Add(Company company, Documents document)
        {
            if (document.Add() != 0)
                throw new Exception(GetLastError(company));
        }

        public string GetLastError(Company company)
        {
            var message = "Erro ao adicionar documento no SAP.\n";
            return $"{message}[{company.GetLastErrorCode()}]-[{company.GetLastErrorDescription()}]";
        }
    }
}
