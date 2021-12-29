namespace DER.WebApp.Infra.Migrations
{
    using DER.WebApp.Common.Helper;
    using DER.WebApp.Domain.Models;
    using DER.WebApp.Domain.Models.Constants;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DER.WebApp.Infra.DAL.DerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.DerContext context)
        {
            /*if (context.Usuario.Count() == 0)
            {
                #region Dados Mestres

                #region Tipo Interessado

                var tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.TipoInteressado.Codigo, Nome = DadosMestresConstants.TipoInteressado.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                var colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Descrição", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Fator Interessado", Tabela = tabelaDadosMestres}
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region Tipo Ocupação

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.TipoOcupacao.Codigo, Nome = DadosMestresConstants.TipoOcupacao.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Tipo de Ocupacao", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region Rodovia

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.Rodovia.Codigo, Nome = DadosMestresConstants.Rodovia.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Sigla da Rodovia", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region UA

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.UA.Codigo, Nome = DadosMestresConstants.UA.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Sigla", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Nome UA", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Unidade", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Regional", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region Unidade

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.Unidade.Codigo, Nome = DadosMestresConstants.Unidade.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Sigla", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Nome", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region Municipio

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.Municipio.Codigo, Nome = DadosMestresConstants.Municipio.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Código", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Municipio", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Regional", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Estado", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region Estado

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.Municipio.Codigo, Nome = DadosMestresConstants.Municipio.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Código", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Sigla", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Estado", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region Natureza Jurídica

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.Municipio.Codigo, Nome = DadosMestresConstants.Municipio.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Código", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Natureza Jurídica", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region Divisao Regional

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.DivisaoRegional.Codigo, Nome = DadosMestresConstants.DivisaoRegional.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Sigla", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Descrição", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Fator Regional", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region PI

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.PI.Codigo, Nome = DadosMestresConstants.PI.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Mes/Ano", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Valor PI", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region IGPM

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.IGPM.Codigo, Nome = DadosMestresConstants.IGPM.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Mês/Ano", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Valor", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region UFESP

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.UFESP.Codigo, Nome = DadosMestresConstants.UFESP.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Mes/Ano", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Valor", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "P (Calculado)", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #region Concessionaria

                tabelaDadosMestres = new DadosMestresTabela() { Codigo = DadosMestresConstants.Concessionaria.Codigo, Nome = DadosMestresConstants.Concessionaria.Nome };
                context.DadosMestresTabela.Add(tabelaDadosMestres);

                colunasDadosMestres = new List<DadosMestresColuna>(){
                    new DadosMestresColuna() { Nome = "Sigla", Tabela = tabelaDadosMestres },
                    new DadosMestresColuna() { Nome = "Nome", Tabela = tabelaDadosMestres }
                };
                context.DadosMestresColuna.AddRange(colunasDadosMestres);

                #endregion

                #endregion

                #region Perfil

                var perfil = new Perfil() { Nome = "Admin Sede", Descricao = "Admin Sede", Permissoes = new List<Permissao>() };

                #region Usuario Interno

                var permissaoPai = new Permissao() { Nome = Permissoes.UsuarioInterno.Nome, Codigo = Permissoes.UsuarioInterno.Codigo };
                perfil.Permissoes.Add(permissaoPai);
                context.Permissao.Add(permissaoPai);
                var permissoes = new List<Permissao>() {
                    new Permissao() {Nome = Permissoes.Cadastrar.Nome, Codigo = Permissoes.Cadastrar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Editar.Nome, Codigo = Permissoes.Editar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Visualizar.Nome, Codigo = Permissoes.Visualizar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Excluir.Nome, Codigo = Permissoes.Excluir.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Listar.Nome, Codigo = Permissoes.Listar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Aprovar.Nome, Codigo = Permissoes.Aprovar.Codigo, PermissaoPai = permissaoPai }
                };
                permissoes.ForEach(x => context.Permissao.Add(x));
                permissoes.ForEach(x => perfil.Permissoes.Add(x));

                #endregion

                #region Usuario Externo

                //Usuario Externo
                permissaoPai = new Permissao() { Nome = Permissoes.UsuarioExterno.Nome, Codigo = Permissoes.UsuarioExterno.Codigo };
                perfil.Permissoes.Add(permissaoPai);
                context.Permissao.Add(permissaoPai);

                permissoes = new List<Permissao>() {
                    new Permissao() {Nome = Permissoes.Cadastrar.Nome, Codigo = Permissoes.Cadastrar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Editar.Nome, Codigo = Permissoes.Editar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Visualizar.Nome, Codigo = Permissoes.Visualizar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Excluir.Nome, Codigo = Permissoes.Excluir.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Listar.Nome, Codigo = Permissoes.Listar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Aprovar.Nome, Codigo = Permissoes.Aprovar.Codigo, PermissaoPai = permissaoPai }
                };
                permissoes.ForEach(x => context.Permissao.Add(x));
                permissoes.ForEach(x => perfil.Permissoes.Add(x));

                #endregion

                #region Grupo

                //Grupo
                permissaoPai = new Permissao() { Nome = Permissoes.Grupo.Nome, Codigo = Permissoes.Grupo.Codigo };
                perfil.Permissoes.Add(permissaoPai);
                context.Permissao.Add(permissaoPai);

                permissoes = new List<Permissao>() {
                    new Permissao() {Nome = Permissoes.Cadastrar.Nome, Codigo = Permissoes.Cadastrar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Editar.Nome, Codigo = Permissoes.Editar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Visualizar.Nome, Codigo = Permissoes.Visualizar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Excluir.Nome, Codigo = Permissoes.Excluir.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Listar.Nome, Codigo = Permissoes.Listar.Codigo, PermissaoPai = permissaoPai }
                };
                permissoes.ForEach(x => context.Permissao.Add(x));
                permissoes.ForEach(x => perfil.Permissoes.Add(x));
                
                #endregion

                #region Perfil

                //Perfil
                permissaoPai = new Permissao() { Nome = Permissoes.Perfil.Nome, Codigo = Permissoes.Perfil.Codigo };
                perfil.Permissoes.Add(permissaoPai);
                context.Permissao.Add(permissaoPai);
                permissoes = new List<Permissao>() {
                    new Permissao() {Nome = Permissoes.Cadastrar.Nome, Codigo = Permissoes.Cadastrar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Editar.Nome, Codigo = Permissoes.Editar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Visualizar.Nome, Codigo = Permissoes.Visualizar.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Excluir.Nome, Codigo = Permissoes.Excluir.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() {Nome = Permissoes.Listar.Nome, Codigo = Permissoes.Listar.Codigo, PermissaoPai = permissaoPai }
                };
                permissoes.ForEach(x => context.Permissao.Add(x));
                permissoes.ForEach(x => perfil.Permissoes.Add(x));

                #endregion

                #region DadosMestres

                permissaoPai = new Permissao() { Nome = Permissoes.DadosMestres.Nome, Codigo = Permissoes.DadosMestres.Codigo };
                perfil.Permissoes.Add(permissaoPai);
                context.Permissao.Add(permissaoPai);

                permissoes = new List<Permissao>() {
                    new Permissao() { Nome = DadosMestresConstants.TipoInteressado.Nome, Codigo = DadosMestresConstants.TipoInteressado.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.TipoOcupacao.Nome, Codigo = DadosMestresConstants.TipoOcupacao.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.Rodovia.Nome, Codigo = DadosMestresConstants.Rodovia.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.UA.Nome, Codigo = DadosMestresConstants.UA.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.Unidade.Nome, Codigo = DadosMestresConstants.Unidade.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.Municipio.Nome, Codigo = DadosMestresConstants.Municipio.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.NaturezaJuridica.Nome, Codigo = DadosMestresConstants.NaturezaJuridica.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.Estado.Nome, Codigo = DadosMestresConstants.Estado.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.DivisaoRegional.Nome, Codigo = DadosMestresConstants.DivisaoRegional.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.PI.Nome, Codigo = DadosMestresConstants.PI.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.IGPM.Nome, Codigo = DadosMestresConstants.IGPM.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.UFESP.Nome, Codigo = DadosMestresConstants.UFESP.Codigo, PermissaoPai = permissaoPai },
                    new Permissao() { Nome = DadosMestresConstants.Concessionaria.Nome, Codigo = DadosMestresConstants.Concessionaria.Codigo, PermissaoPai = permissaoPai }
                };
                context.Permissao.AddRange(permissoes);

                foreach (var permissao in permissoes)
                {
                    context.Permissao.AddRange(
                        new List<Permissao>() {
                            new Permissao() {Nome = Permissoes.Cadastrar.Nome, Codigo = Permissoes.Cadastrar.Codigo, PermissaoPai = permissao },
                            new Permissao() {Nome = Permissoes.Editar.Nome, Codigo = Permissoes.Editar.Codigo, PermissaoPai = permissao },
                            new Permissao() {Nome = Permissoes.Visualizar.Nome, Codigo = Permissoes.Visualizar.Codigo, PermissaoPai = permissao },
                            new Permissao() {Nome = Permissoes.Excluir.Nome, Codigo = Permissoes.Excluir.Codigo, PermissaoPai = permissao }
                        }
                    );
                }
                #endregion

                context.Perfil.Add(perfil);
                context.SaveChanges();

                #endregion

                #region Grupo
                
                var grupo = new Grupo() { Nome = "Admin Sede", Descricao = "Admin Sede", Perfil = perfil };

                context.Grupo.Add(grupo);
                context.SaveChanges();

                #endregion

                #region Status Aprovacao

                var StatusAprovacao = new List<StatusAprovacao>()
                {
                    new StatusAprovacao(){ Nome = "Aguardando aprovacão" },
                    new StatusAprovacao(){ Nome = "Reprovado" },
                    new StatusAprovacao(){ Nome = "Aprovado" }
                };
                context.StatusAprovacao.AddRange(StatusAprovacao);
                context.SaveChanges();

                #endregion

                #region Usuario


                var usuario = new Usuario() { Nome = "Admin", Cargo = "Admin", DataCriacao = DateTime.Now, DDD = "00", Login = "Admin", Senha = Criptografar.Encrypt("admin"), Externo = false, TelefoneRamal = "", Email = "teste@teste.com", Ativo = true, Grupos = new List<Grupo>() { grupo }, StatusAprovacaoId = 3 };
                context.Usuario.Add(usuario);
                context.SaveChanges();

                #endregion

            }*/

        }
    }
}
