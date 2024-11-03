


$(document).ready(function () {

    $('#Expense').DataTable({
        language: {
            
            "decimal": "",
            "emptyTable": "Nenhum registro encontrado",
            "info": "Mostrando _START_ até _END_ de _TOTAL_ registros",
            "infoEmpty": "Mostrando 0 até 0 de 0 registros",
            "infoFiltered": "(filtrado de _MAX_ registros totais)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ registros",
            "loadingRecords": "Carregando...",
            "processing": "",
            "search": "Pesquisar:",
            "zeroRecords": "Nenhuma ocorrência encontrada",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Ordenado por está coluna",
                "orderableReverse": "Ordem reversa desta coluna"
            }
        
        }
    });

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    }, 5000);

});

$(function () {
    var amount = 0;

    $(".amount").each(function () {
        var value = $(this).text().replace("R$", "").replace(".", "").replace(",", ".");
        amount += parseFloat(value) || 0; 
    });
    $("#totalAmount").text("R$ " + amount.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
})