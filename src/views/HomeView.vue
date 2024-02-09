<template>
  <div id="container" class="container">
    <div class="row justify-content-center align-items-center min-vh-100">
      <div class="col-lg-6">
        <div class="card">
          <div class="card-body">
            <h2 class="card-title text-center">Work Watch</h2>
            <a-form
              name="horizontal_login"
              layout="vertical"
              autocomplete="off"
              @finish="onFinish"
              @submit="handleSubmit"
            >
              <a-form-item
                :name="['login', 'document']"
                :validate-status="validateStatus.document"
                :help="helpText.document"
              >
              <label class="label-input">Documento do empregado</label>
                <a-input placeholder="Documento" name="document" v-model:value="formState.login.document" @input="handleInput('document', $event)">
                  <template #prefix>
                    <UserOutlined class="site-form-item-icon" />
                  </template>
                </a-input>
              </a-form-item>

              <a-form-item 
                name="password" 
                :validate-status="validateStatus.password"
                :help="helpText.password"
              >
              <label class="label-input">Senha</label>
                <a-input-password placeholder="Senha" name="password" v-model:value="formState.login.password" @input="handleInput('password', $event)">
                  <template #prefix>
                    <LockOutlined class="site-form-item-icon" />
                  </template>
                </a-input-password>
              </a-form-item>

              <a-form-item class="text-center">
                <a-button type="primary" :loading="loading.loadingButton" html-type="submit">Entrar</a-button>
              </a-form-item>
            </a-form>
            <div class="msg-desc">
              Tenha o controle total sobre as atividades de trabalho de sua equipe, 
              garantindo maior eficiência e produtividade.
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { formatDocument } from '../utils/document'
import { UserOutlined, LockOutlined } from '@ant-design/icons-vue'

const formState = ref({
  login: {
    document: '',
    password: ''
  }
})

const loading = ref({
  loadingButton: false,
  loadingScreen: false
})

const validateStatus = ref({
  document: '',
  password: ''
})

const helpText = ref({
  document: '',
  password: ''
})

const handleSubmit = () => {
  loading.value.loadingButton = true
  const documentValidation = validateField('document')
  const passwordValidation = validateField('password')

  if (documentValidation.valid && passwordValidation.valid) {
    loading.value.loadingButton = false
    console.log('Envio de informações')
  } else {
    loading.value.loadingButton = false
    console.log('Preencha os campos corretamente')
  }
}

const handleInput = (fieldName, event) => {
  const { value } = event.target
  const formattedValue = formatField(fieldName, value)

  formState.value.login[fieldName] = formattedValue
  validateStatus.value[fieldName] = ''
  helpText.value[fieldName] = ''
}

const validateField = (fieldName) => {
  const value = formState.value.login[fieldName]
  const validation = { valid: true, message: '' }

  if (!value) {
    validation.valid = false
    validation.message = 'Preencha esse campo.'
    validateStatus.value[fieldName] = 'error'
  } else if (fieldName === 'document' && value.length !== 14) {
    validation.valid = false
    validation.message = 'Preencha corretamente.'
    validateStatus.value[fieldName] = 'warning'
  } else {
    validateStatus.value[fieldName] = ''
  }

  helpText.value[fieldName] = validation.message

  return validation
}

const formatField = (fieldName, value) => {
  if (fieldName === 'document') {
    return formatDocument(value).slice(0, 14).trim()
  } else {
    return value.slice(0, 50).trim()
  }
}

const onFinish = () => {
  console.log('Finish')
}
</script>
