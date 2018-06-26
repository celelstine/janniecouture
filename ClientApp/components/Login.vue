<template>
    <div class="container">
        <!-- Button to Open the Modal -->
        <!-- The Modal -->
        <div class="modal fade" id="loginModal">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Login </h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <h4 v-if="hasMessage" class="text-center text-warning">  {{  message }}</h4>
                        <div class="form-group">
                            <label for="email">Email:</label>
                            <input
                                   type="email"
                                   v-bind:class="emailStyle"
                                   id="email"
                                   autocomplete="email"
                                   v-model="email">
                            <div class="invalid-feedback">
                                Please provide a valid email.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="pwd">Password:</label>
                            <input
                                   type="password"
                                   v-bind:class="passwordStyle"
                                   id="password"
                                   autocomplete="password"
                                   v-model="password">
                            <div class="invalid-feedback">
                                Password should contain at least 6 characters.
                            </div>
                        </div>
                        <div class="form-group form-check">
                            <label class="form-check-label">
                                <input class="form-check-input" type="checkbox" v-model="rememberMe"> Remember me
                            </label>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button
                                type="button"
                                class="btn btn-primary"
                                v-bind:disabled="inValidForm"
                                v-on:click="handleLogin"
                        >Login</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>

                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapActions, mapState } from 'vuex';
import {
  isValidatePassword,
  isValidEmail,
    } from '../validators.js';

export default {
    name: 'Login',
    computed: {
        ...mapState('auth', {
            message: state => state.message,
            jwt: state => state.jwt,
            hasMessage: state => state.messageForLogin,
        }),
    },
    methods: {
        handleLogin(event) {
              event.preventDefault();
              const credentails = {
                Email: this.email,
                Password: this.password,
                // rememberMe: this.rememberMe,
              };
              this.$store.dispatch('auth/login', credentails);
        },
        checkForm(field, operation) {
            let validInputs = this.validInputs;
            const fieldIndex = validInputs.indexOf(field);
            const fieldCSSClass = `${field}Style`;

            if (operation === 'add') {
                this[fieldCSSClass] = this[fieldCSSClass].toString().replace('is-invalid', '');
                if (fieldIndex === -1) {
                  validInputs.push(field);
                }
            } else if (operation === 'remove') {
                if (fieldIndex !== -1) {
                    this[fieldCSSClass] += ' is-invalid';
                  validInputs = validInputs
                    .filter((item, index) => index !== fieldIndex);
                }
              }

              this.validInputs = validInputs;

              // disable the submit button when every field are not valid
              if (validInputs.length === 2) {
                this.inValidForm = false;
              } else {
                this.inValidForm = true;
              }
        },
    },
    data() {
        return {
            email: '',
            password: '',
            rememberMe: true,
            inValidForm: true,
            validInputs: [],
            emailStyle: 'form-control',
            passwordStyle: 'form-control'

        };
      },
      watch: {
        email(val) {
          if (!isValidEmail(val)) {
            this.checkForm('email', 'remove');
          } else {
            this.checkForm('email', 'add');
          }
        },
        password(val) {
          if (!isValidatePassword(val)) {
            this.checkForm('password', 'remove');
          } else {
            this.checkForm('password', 'add');
          }
        },
        jwt(val) {
          if (val) {
            document.getElementById('loginModal').style.display = 'none';
            // hide bootstrap4 overlay
            document.getElementsByClassName('modal-backdrop')[0].style.display = 'none';

          }
        },
      },
}
</script>

<style>
    .close{
        color: white;
    }
    .modal-header {
        color: white;
        background: #153466
    }
    .modal-content {
        border: 0px;
    }
    .modal-footer .btn-primary {
         background: #153466
    }
</style>