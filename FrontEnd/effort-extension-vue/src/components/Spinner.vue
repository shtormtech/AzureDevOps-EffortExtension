<template lang="pug">
.spinner-wrapper
  #spinner
</template>
<script>
export default {
  name: 'Spinner'
}
</script>
<style lang="scss" scoped>
.spinner-wrapper {
  position: relative;
  height: 100%;
  width: 100%;
  min-height: 25px;
  min-width: 25px;

}
#spinner {
  display: block;
  position: absolute;
  top: 50%;
  left: 50%;
  height: 20px;
  width: 20px;
  border: 4px rgb(216, 236, 249) solid;
  border-top: 4px #007bd0 solid;
  border-radius: 50%;
  -webkit-animation: spin2 1s infinite linear;
          animation: spin2 1s infinite linear;
}

@-webkit-keyframes spin2 {
  from {
    -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
  }
  to {
    -webkit-transform: rotate(359deg);
            transform: rotate(359deg);
  }
}
@keyframes spin2 {
  from {
    -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
    -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
  }
  to {
    -webkit-transform: rotate(359deg);
            transform: rotate(359deg);
    -webkit-transform: rotate(359deg);
            transform: rotate(359deg);
  }
}
</style>
