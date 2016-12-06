﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagarMe.Tests
{
	public class PagarMeTestFixture
	{

        //private static BankAccount bank = null;

        static PagarMeTestFixture ()
		{
			PagarMeService.DefaultApiKey = "ak_test_AAAfFBJDvGNMA6YMEoxRyIrK0PlhLI";
			PagarMeService.DefaultEncryptionKey = "ek_test_D8fnTNOqaPBQx46QBiDprUzeophI7q";
		}


        public static Recipient CreateRecipientWithAnotherBankAccount()
        {
            BankAccount bank = new BankAccount
            {
                BankCode = "341",
                Agencia = "0609",
                Conta = "03032",
                ContaDv = "5",
                DocumentNumber = "44417398850",
                LegalName = "Fellipe"
            };

            bank.Save();

            return new Recipient()
            {
                TransferInterval = TransferInterval.Monthly,
                TransferDay = 5,
                TransferEnabled = true,
                BankAccount = bank
            };
        }

        public static Recipient CreateRecipient(BankAccount bank)
        {
            return new Recipient()
            {
                TransferInterval = TransferInterval.Monthly,
                TransferDay = 5,
                TransferEnabled = true,
                BankAccount = bank
            };
        }

        public static Recipient CreateRecipient()
        {
            BankAccount bank = CreateTestBankAccount();
            bank.Save();
            return new Recipient()
            {
                TransferInterval = TransferInterval.Monthly,
                TransferDay = 5,
                TransferEnabled = true,
                BankAccount = bank
            };

        }

        public static Transfer CreateTestTransfer(string bank_account_id,string recipient_id)
        {
            return new Transfer
            {
                Amount = 1000,
                RecipientId = recipient_id,
                BankAccountId = bank_account_id
            };

        }

		public static Plan CreateTestPlan ()
		{
			return new Plan () {
				Name = "Test Plan",
				Days = 30,
				TrialDays = 0,
				Amount = 1099,
				Color = "#787878",
				PaymentMethods = new PaymentMethod[] { PaymentMethod.CreditCard }
			};
		}

		public static BankAccount CreateTestBankAccount ()
		{
			return new BankAccount () {
				BankCode = "184",
				Agencia = "0808",
				AgenciaDv = "8",
				Conta = "08808",
				ContaDv = "8",
				DocumentNumber = "43591017833",
				LegalName = "TesteTestadoTestando"
			};
		}

		public static Transaction CreateTestTransaction ()
		{
			return new Transaction {
				Amount = 1099,
				PaymentMethod = PaymentMethod.CreditCard,
				CardHash = GetCardHash()
			};
		}

        public static Transaction CreateTestBoletoTransaction()
        {
            return new Transaction
            {
                Amount = 100000,
                PaymentMethod = PaymentMethod.Boleto
            };
        }

        public static Transaction CreateTestCardTransactionWithInstallments()
        {
            return new Transaction
            {
                Amount = 1099,
                PaymentMethod = PaymentMethod.CreditCard,
                Installments = 5,
                CardHash = GetCardHash()
            };
        }

        public static Transaction CreateBoletoSplitRuleTransaction(Recipient recipient)
        {
            return new Transaction
            {
                Amount = 10000,
                PaymentMethod = PaymentMethod.Boleto,
                SplitRules = CreateSplitRule(recipient)
            };
        }

        public static SplitRule[] CreateSplitRule(Recipient recipient)
        {
            List<SplitRule> splits = new List<SplitRule>();
            Recipient rec = CreateRecipient();
            rec.Save();

            SplitRule split1 = new SplitRule()
            {
                Recipient = rec,
                Percentage = 10
            };

            SplitRule split2 = new SplitRule()
            {
                Recipient = recipient,
                Percentage = 90
            };

            splits.Add(split1);
            splits.Add(split2);

            return splits.ToArray();

        }

		public static string GetCardHash ()
		{
			var creditcard = new CardHash ();

			creditcard.CardHolderName = "Jose da Silva";
			creditcard.CardNumber = "5433229077370451";
			creditcard.CardExpirationDate = "1021";
			creditcard.CardCvv = "018";

			return creditcard.Generate ();
		}

        public static Payable returnPayable(int id)
        {
            return PagarMeService.GetDefaultService().Payables.Find(id);
        }
/*
        public static Payable[] returnAllPayables()
        {
            Payable payable = new Payable()
            {
                PayableStatus = PayableStatus.Paid
            };

            return  PagarMeService.GetDefaultService().Payables.FindAll(payable).ToArray();
        }
*/

	}
}
