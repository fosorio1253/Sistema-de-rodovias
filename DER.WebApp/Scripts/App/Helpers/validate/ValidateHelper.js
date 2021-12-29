var ValidateHelper = {
    validarCampos:function(campos) {
        let valid = true;
        campos.forEach(field => { 
            console.log('---field:', field);
            console.log('$(field):', $(field));
            if(!$(field).length) valid = false; 
            else if (!$(field).valid()) valid = false; 
        });
        return valid;
    }
};
export default ValidateHelper;