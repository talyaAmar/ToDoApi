import axios from 'axios';

//const apiUrl = "https://localhost:7271"
const apiUrl =process.env.REACT_APP_API_URL;
export default {
  getTasks: async () => {
    const result = await axios.get(`${apiUrl}/items`)    
    return result.data;
  },

  addTask: async(name)=>{
    console.log('addTask', name)
    const result = await axios.post(`${apiUrl}/addTask`,{name:`${name}`})    
    return {};
  },

  setCompleted: async(id, isComplete)=>{

    console.log('setCompleted', {id, isComplete})
    const result = await axios.put(`${apiUrl}/update/${id}`, { isComplete });
    return result.data;
  },

  deleteTask:async(id)=>{
    console.log('deleteTask')
    const result = await axios.delete(`${apiUrl}/delete/${id}`)
    return result.data;
  }
};
