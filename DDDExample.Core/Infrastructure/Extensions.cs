using System;
using DDDExample.Core.Application.EventHandlers;
using DDDExample.Core.Application.Services;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Core.Domain.Model;
using DDDExample.Core.Domain.Model.Events;
using DDDExample.Core.Domain.Repositories;
using DDDExample.Core.Domain.Services;
using DDDExample.Core.Infrastructure.Events;
using DDDExample.Core.Infrastructure.Repositories;
using DDDExample.Core.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DDDExample.Core.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddInfrastructureDependencies()
                .AddApplicationDependencies();
        }

        private static IServiceCollection AddInfrastructureDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IEventPublisher, EventPublisher>()
                .AddTransient<IRepository<DayBooking, Guid>, InMemoryRepository<DayBooking, Guid>>()
                .AddTransient<IDayBookingRepository, DayBookingRepository>()
                .AddTransient<IBookingCacheService, BookingCacheService>()
                .AddTransient<IBookingSettingService, BookingSettingService>();
        }
        
        private static IServiceCollection AddApplicationDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IBookingService, BookingService>()
                .AddTransient<IEventHandler<BookingCreated>, BookingCreatedEventHandler>()
                .AddTransient<IEventHandler<BookingCancelled>, BookingCancelledEventHandler>();
        }
    }
}