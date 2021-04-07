import axios from 'axios';

export default {

  getBeers(){
      return axios.get('/beer')
  }

}