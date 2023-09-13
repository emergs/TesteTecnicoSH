$(document).ready(function () {

    $('#tableClient').DataTable({
        "pageLength": 20,
        "searching": false,
        "ordering": false,
        "lengthChange": false,
        "language": {
            "decimal": "",
            "emptyTable": "Nenhum registro encontrado",
            "info": "Exibindo de_START_ a _END_ do total de _TOTAL_ registros",
            "infoEmpty": "0",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Show _MENU_ entries",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Search:",
            "zeroRecords": "Nenhum registro encontrado",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        }
    });

    setTimeout(() => {
        $(".alert").fadeOut("slow", () => {
            $(this).alert('close');
        })
    }, 5000)

    $('#btnFilter').click(()=> {
        $('#divFilter').fadeIn();
    });

    $('#btnCloseFilter').click(() => {
        $('#divFilter').fadeOut();
    });

    $('#dataFiltro').mask('00/00/0000');

    $('#telefone').mask('(00) 00000-0000');

    $('#cpfCnpj').on('input', function () {
        let valor = $(this).val().replace(/\D/g, '');

        if (valor.length <= 11) {
            $(this).mask('000.000.000-00', { reverse: true });
        } else if (valor.length > 11 && valor.length <= 14) {
            $(this).unmask(); 
            $(this).mask('00.000.000/0000-00', { reverse: true });
        } else {
            $(this).unmask(); 
        }
    });

    $('#inscEstadual').mask('000.000.000-000', { reverse: true });

    $('#isento').click(function () {
        if ($(this).is(':checked')) {
            $('#inscEstadual').prop('disabled', true);
        } else {
            $('#inscEstadual').prop('disabled', false);
        }
    });

    $('#tipoPessoa').change(function () {
        let value = $(this).val();
        console.log(value)

        if (value === 'Fisica') {
            $('#infoPessoaFisica').show();
        }
        else {
            $('#infoPessoaFisica').hide();
        }
    })

})