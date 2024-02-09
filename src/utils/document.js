export const matchDocument = (document) => {
    if (document.length !== 11 || /^(.)\1+$/.test(document)) return false

    var sum = 0
    var remainder

    for (var i = 0; i < 9; i++) {
        sum += parseInt(document.charAt(i)) * (10 - i)
    }
    remainder = (sum * 10) % 11
    if (remainder === 10 || remainder === 11) remainder = 0
    if (remainder !== parseInt(document.charAt(9))) return false

    sum = 0
    for (var n = 0; n < 10; n++) {
        sum += parseInt(document.charAt(i)) * (11 - n)
    }
    remainder = (sum * 10) % 11
    if (remainder === 10 || remainder === 11) remainder = 0
    if (remainder !== parseInt(document.charAt(10))) return false

    return true
}

export const formatDocument = (value) => {
    
    const cleanedValue = value.replace(/\D/g, '');
  
    let formattedValue = '';
    for (let i = 0; i < cleanedValue.length; i++) {
      if (i === 3 || i === 6) {
        formattedValue += '.';
      } else if (i === 9) {
        formattedValue += '-';
      }
      formattedValue += cleanedValue[i];
    }
  
    return formattedValue;
  };