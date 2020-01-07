new Vue({
    el: '#tplAccount',
    template: '#tplAccount',
    data: {
        form: {
            Code: '',
            Password: ''
        },
        formSet: {
            loginLoading: false,
            txtLogin: '登陆'
        }
    },
    methods: {
        btnlogin() {
            this.$data.formSet.loginLoading = true;
            axios.post('/Account/Login', this.$data.form)
                .then(res => {
                    this.$data.formSet.loginLoading = false;
                    if (res.data.code != 1) {
                        this.$message.error({ showClose: true, message: res.data.errorMsg });
                        return;
                    }
                    this.$message({ message: '登陆成功' });
                    setTimeout(() => {
                        window.location.href = '/Home/Index';
                    }, 500);
                }).catch(error => {
                    this.$data.formSet.loginLoading = false;
                    this.$alert(error);
                })
        }
    }
})