'use strict';
class Crud {
    #variaveis = {
        controlador: '',
        idCliente: 0,
        idTipoTelefone: '',
        tipoTelefone: '',
        operadora: '',
        numeroTelefone: '',
        ativo:'',
        telefones: []
    }

    constructor(config) {
        this.#variaveis.controlador = config.controlador || '';
    }

    requests = {
        ultimosDados: () => {
            return new Promise((resolve, reject) => {
                $.ajax({
                    type: "get",
                    url: `./${this.#variaveis.controlador}?handler=GetLatestData`,
                    headers: {
                        RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    contentType: "application/json",
                    success: function (data) {
                        resolve(data);
                    }
                });
            })
        },    
        addTelefone: (data) => {
            return new Promise((resolve, reject) => {
                $.ajax({
                    type: "POST",
                    url: `./${this.#variaveis.controlador}?handler=addNewTelefone`,
                    headers: {
                        RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    data: data,
                    success: function (response) {
                        $('#contatos').html(response);
                        resolve();
                    },
                    failure: function (response) {
                        console.error(response);
                        reject();
                    }
                });
            })
        },
        deleteTelefone: (numero, data) => {

            const idx = data['telefones'].filter(d => d.numeroTelefone == numero);
            data['telefones'].splice(idx, 1);

            return new Promise((resolve, reject) => {
                $.ajax({
                    type: "POST",
                    url: `./${this.#variaveis.controlador}?handler=removeTelefone`,
                    headers: {
                        RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    data: data,
                    success: function (response) {
                        $('#contatos').html(response);
                        resolve();
                    },
                    failure: function (response) {
                        console.error(response);
                        reject();
                    }
                });
            })
        }
    };

    functions = {
        addNewTelefone: (e) => {
            e.preventDefault();

            var data = this.#parametros.montar();

            if (this.#parametros.valido()) {
                toastr.warning("Preencha todos os campos!", "Telefone");
                $('#formTelefone').valid();
                return false;
            }

            var model;

            this.requests.ultimosDados().then((response) => {
                model = response;
                model['telefones'] = this.#variaveis.telefones || [];
                model['telefones'].push(data);
                this.requests.addTelefone(model).then((d) => {
                    this.#variaveis.telefones = Object.assign([], model['telefones']);
                    toastr.success("Adicionado com sucesso", "Telefone");
                    this.#parametros.limpar();
                }).catch(error => {
                    console.error(`Ocorreu um erro: ${error}`);
                    toastr.error("Falha inesperada, por favor tente mais tarde!", "Telefone");
                })
            }).catch(error => {
                console.error(`Ocorreu um erro: ${error}`);
                toastr.error("Falha inesperada, por favor tente mais tarde!", "Telefone");
            });
        }
        ,
        removeTelefone: (numero) => {
            var model;

            this.requests.ultimosDados().then((response) => {
                model = response;

                this.requests.deleteTelefone(numero, model).then((d) => {
                    toastr.success("Telefone", "Removido com sucesso");
                    this.#variaveis.telefones = Object.assign([], model['telefones']);
                }).catch(error => {
                    console.error(`Ocorreu um erro: ${error}`);
                    toastr.error("Falha inesperada, por favor tente mais tarde!", "Telefone");
                });
            });
        }
        ,
        submit: (event) => {

            if (!this.#variaveis.telefones || this.#variaveis.telefones.length == 0) {
                event.preventDefault();
                toastr.warning("Informe pelo meno 1 telefone!", "Telefone");
                return false;
            }

            $("#form").submit();
            return true;

        },
        load: () => {
            this.requests.ultimosDados().then((response) => {
                this.#variaveis.telefones = Object.assign([], response['telefones']);
            });
        }
    };

    #parametros = {
        
        
        montar: () => {
            this.#variaveis.idTipoTelefone = $("#tipotelefone option:selected").val();
            this.#variaveis.tipoTelefone = $("#tipotelefone option:selected").text();
            this.#variaveis.operadora = $("#operadora").val();
            this.#variaveis.numeroTelefone = $("#numero").val();
            this.#variaveis.ativo = $('#ativo').is(':checked');
            this.#variaveis.idCliente = $("#Cliente_Id").val();

            var data = {
                IdTipoTelefone: Number(this.#variaveis.idTipoTelefone),
                TipoTelefone: this.#variaveis.tipoTelefone,
                Operadora: this.#variaveis.operadora,
                NumeroTelefone: this.#variaveis.numeroTelefone,
                Ativo: this.#variaveis.ativo,
                IdCliente: this.#variaveis.idCliente || 0
            };

            return data;
        },
        limpar: () => {
            $("#tipotelefone option:nth(0)").attr('selected', 'true');
            $("#operadora").val('');
            $("#numero").val('');
            $('#ativo').prop('checked', true);
        },
        valido: () => !this.#variaveis.idTipoTelefone || !this.#variaveis.operadora || !this.#variaveis.numeroTelefone
    };
}

function parserJson(valor) {
    if (!valor) return valor;

    return JSON.parse(new DOMParser().parseFromString(valor, "text/html").documentElement.textContent);
}