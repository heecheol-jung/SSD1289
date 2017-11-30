/**
  ******************************************************************************
  * File Name          : main.c
  * Description        : Main program body
  ******************************************************************************
  ** This notice applies to any and all portions of this file
  * that are not between comment pairs USER CODE BEGIN and
  * USER CODE END. Other portions of this file, whether 
  * inserted by the user or by software development tools
  * are owned by their respective copyright owners.
  *
  * COPYRIGHT(c) 2017 STMicroelectronics
  *
  * Redistribution and use in source and binary forms, with or without modification,
  * are permitted provided that the following conditions are met:
  *   1. Redistributions of source code must retain the above copyright notice,
  *      this list of conditions and the following disclaimer.
  *   2. Redistributions in binary form must reproduce the above copyright notice,
  *      this list of conditions and the following disclaimer in the documentation
  *      and/or other materials provided with the distribution.
  *   3. Neither the name of STMicroelectronics nor the names of its contributors
  *      may be used to endorse or promote products derived from this software
  *      without specific prior written permission.
  *
  * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
  * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
  * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
  * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
  * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
  * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
  * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
  * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
  * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
  * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
  *
  ******************************************************************************
  */

/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "stm32f4xx_hal.h"
#include "usart.h"
#include "gpio.h"
#include "fsmc.h"

/* USER CODE BEGIN Includes */
#include <string.h>
#include <stdlib.h>
#include "ssd1289.h"

#define UART1_RCV_BUF_SIZE  (1)
#define PARSE_BUF_SIZE      (128)
#define ARG_BUF_SIZE        (32)
#define DELIMITER_CMD_END   ('\n')
#define ELIMITER_CMD_ARG    (' ')

#define CMD_UNKNOWN         (0)
#define CMD_RD              (1)
#define CMD_WR              (2)
/* USER CODE END Includes */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */
uint8_t   _g_bufRcv1[UART1_RCV_BUF_SIZE];
char      _g_bufSend1[PARSE_BUF_SIZE];
char      _g_bufParse[PARSE_BUF_SIZE];
char      _g_bufArg[ARG_BUF_SIZE];
uint16_t  _g_parseCount = 0;
uint8_t   _g_regAddr = 0;
uint16_t  _g_regValue = 0;
uint8_t   _g_commandId = CMD_UNKNOWN;
/* Private variables ---------------------------------------------------------*/

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);

/* USER CODE BEGIN PFP */
/* Private function prototypes -----------------------------------------------*/
void ParseCommand(void)
{
  uint16_t i = 0, j = 0;
  
  // RD command
  if (_g_bufParse[0] == 'R' && _g_bufParse[1] == 'D')
  {
    // Register address
    for (i = 3; i < _g_parseCount; i++)
    {
      if (_g_bufParse[i] == DELIMITER_CMD_END)
      {
        _g_bufArg[j] = 0;
        break;
      }
      _g_bufArg[j++] = _g_bufParse[i];
    }
    
    _g_regAddr = atoi(_g_bufArg);
    _g_commandId = CMD_RD;
  }
  else if (_g_bufParse[0] == 'W' && _g_bufParse[1] == 'R')
  {   
    // Register address
    for (i = 3; i < _g_parseCount; i++)
    {
      if (_g_bufParse[i] == ELIMITER_CMD_ARG)
      {
        _g_bufArg[j] = 0;
        break;
      }
      _g_bufArg[j++] = _g_bufParse[i];
    }
    _g_regAddr = atoi(_g_bufArg);
    
    // Register value
    j = 0;
    for (; i < _g_parseCount; i++)
    {
      if (_g_bufParse[i] == DELIMITER_CMD_END)
      {
        _g_bufArg[j] = 0;
        break;
      }
      _g_bufArg[j++] = _g_bufParse[i];
    }
    _g_regValue = atoi(_g_bufArg);
    
    _g_commandId = CMD_WR;
  }
}
/* USER CODE END PFP */

/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

int main(void)
{

  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration----------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_USART1_UART_Init();
  MX_FSMC_Init();

  /* USER CODE BEGIN 2 */
  // Enable USART rx interrupt.
  HAL_UART_Receive_IT(&huart1, _g_bufRcv1, UART1_RCV_BUF_SIZE);
  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    if (_g_commandId != CMD_UNKNOWN)
    {
      int len = 0;
      
      // TODO : Read/Write register.
      if (_g_commandId == CMD_RD)
      {
        _g_regValue = ssd1289_read_reg(_g_regAddr);
        len = sprintf(_g_bufSend1, "RD %d %d%c", _g_regAddr, _g_regValue, DELIMITER_CMD_END);
      }
      else if (_g_commandId == CMD_WR)
      {
        ssd1289_write_reg(_g_regAddr, _g_regValue);
        len = sprintf(_g_bufSend1, "WR%c", DELIMITER_CMD_END);
      }
      
      HAL_UART_Transmit_IT(&huart1, (uint8_t*)_g_bufSend1, len);
      
      _g_commandId = CMD_UNKNOWN;
    }
  /* USER CODE END WHILE */

  /* USER CODE BEGIN 3 */

  }
  /* USER CODE END 3 */

}

/** System Clock Configuration
*/
void SystemClock_Config(void)
{

  RCC_OscInitTypeDef RCC_OscInitStruct;
  RCC_ClkInitTypeDef RCC_ClkInitStruct;

    /**Configure the main internal regulator output voltage 
    */
  __HAL_RCC_PWR_CLK_ENABLE();

  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE1);

    /**Initializes the CPU, AHB and APB busses clocks 
    */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 8;
  RCC_OscInitStruct.PLL.PLLN = 336;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV2;
  RCC_OscInitStruct.PLL.PLLQ = 4;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    _Error_Handler(__FILE__, __LINE__);
  }

    /**Initializes the CPU, AHB and APB busses clocks 
    */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV4;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV2;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_5) != HAL_OK)
  {
    _Error_Handler(__FILE__, __LINE__);
  }

    /**Configure the Systick interrupt time 
    */
  HAL_SYSTICK_Config(HAL_RCC_GetHCLKFreq()/1000);

    /**Configure the Systick 
    */
  HAL_SYSTICK_CLKSourceConfig(SYSTICK_CLKSOURCE_HCLK);

  /* SysTick_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(SysTick_IRQn, 0, 0);
}

/* USER CODE BEGIN 4 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{  
  if (_g_parseCount >= PARSE_BUF_SIZE)
  {
    
    _g_parseCount = 0;
  }
  _g_bufParse[_g_parseCount++] = _g_bufRcv1[0];
  
  if (_g_bufRcv1[0] == DELIMITER_CMD_END)
  {
    ParseCommand();
    _g_parseCount = 0;
  }
  
  // Enable USART rx interrupt.
  HAL_UART_Receive_IT(&huart1, _g_bufRcv1, UART1_RCV_BUF_SIZE);
}
/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @param  None
  * @retval None
  */
void _Error_Handler(char * file, int line)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  while(1) 
  {
  }
  /* USER CODE END Error_Handler_Debug */ 
}

#ifdef USE_FULL_ASSERT

/**
   * @brief Reports the name of the source file and the source line number
   * where the assert_param error has occurred.
   * @param file: pointer to the source file name
   * @param line: assert_param error line source number
   * @retval None
   */
void assert_failed(uint8_t* file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
    ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */

}

#endif

/**
  * @}
  */ 

/**
  * @}
*/ 

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
