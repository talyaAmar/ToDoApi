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

  // setCompleted: async(id, isComplete)=>{

  //   console.log('setCompleted', {id, isComplete})
  //   const result = await axios.put(`${apiUrl}/update/${id}`, { isComplete });
  //   return result.data;
  // },

  setCompleted: async (id, isComplete, name) => {
    console.log('setCompleted', { id, isComplete, name });
  
    try {
      const result = await axios.put(`${apiUrl}/update/${id}`, { 
        Name: name, // העברת שם המשימה 
        IsComplete: isComplete
      });
      await axios.get(`${apiUrl}/items`); // קריאה לפונקציה שמעדכנת את הרשימה
      return result.data;
    } catch (error) {
      console.error("שגיאה בעדכון המשימה:", error);
      return null;
    }
  },
  deleteTask:async(id)=>{
    console.log('deleteTask')
    const result = await axios.delete(`${apiUrl}/delete/${id}`)
    return result.data;
  }
};
