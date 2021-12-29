var UploadHelper = {
    getBase64:function (file) {
        if (file == null) return "";

        var reader = new FileReader();
        return new Promise((resolve, reject) => {
            reader.onerror = () => {
                reader.abort();
                reject(new DOMException("Problem parsing input file."));
            };
            reader.onload = () => {
                resolve(reader.result);
            };
            reader.readAsDataURL(file);
        });
    },
    getFileAndName: async function(inputId){
        let Upload = null;
        let Nome = "";
        let input = $(inputId);
        if (input[0] && input[0].files && input[0].files.length) {
            Upload = input[0].files[0];
            Nome = input[0].files[0].name;
        }
        const Arquivo = await UploadHelper.getBase64(Upload);
        return { Nome, Arquivo };
    },
    addlistenerChangeInputFileAndApplyLock:function(){
        $('input:file').change((e) => {
            var ext = $(e.target).val().split('.').pop().toLowerCase();
            if ($.inArray(ext, ['pdf', 'jpg', 'jpeg']) == -1) {
                swal({
                    title: "Erro",
                    type: 'error',
                    text: 'Somente arquivos JPG, JPEG ou PDF são permitidos!'
                });
                $(e.target).val('');
                return;
            }
    
            var filesize = $(e.target)[0].files[0].size / 1024 / 1024;
            if (filesize > 100) {
                swal({
                    title: "Erro",
                    type: 'error',
                    text: 'Somente arquivos com até 100 MB de tamanho são permitidos!'
                });
                $(e.target).val('');
            }
        });
    }
};
export default UploadHelper;