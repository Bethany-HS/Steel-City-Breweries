import axios from 'axios';

export default {

  getBeers(){
      return axios.get('/beer')
  },

  addBeer(beer){
    return axios.post('/beer', beer)
  }

}