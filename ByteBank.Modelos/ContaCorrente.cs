﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
            /// <summary>
            /// Define uma conta Conta Corrente do banco ByteBank.
            /// </summary>
    public class ContaCorrente
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }
            /// <summary>
            /// Cria uma instância de ContaCorrente com os argumentos utilizados.
            ///</summary>
            ///<param name = "agencia" > Representa o valor da propriedade<see cref= "Agencia" /> e deve possuir um valor maior que zero. </param>
            ///<param name = "numero" > Representa o valor da propriedade< see cref = "Numero" /> e deve possuir um valor maior que zero. </param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor de <see cref="Saldo"/>
        /// </summary>
        /// <exception cref="ArgumentException">Execão lançada quando um valor negativo é usado no argumento<paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/></exception>
        /// <param name="valor">Representa o valor do saque, deve ser maior que 0 e maior que <see cref="Saldo"/></param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        /// <summary>
        /// Deposita o valor e atualiza o valor de <see cref="Saldo"/>see
        /// </summary>
        /// <param name="valor">Valor do saque</param>
        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        /// <summary>
        /// Transefere o dinheiro de uma conta para outra e atualiza o <see cref="Saldo"/> de ambas
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="contaDestino"></param>
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }
    }

}
